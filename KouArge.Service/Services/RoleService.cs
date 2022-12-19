using AutoMapper;
using KouArge.Core.DTOs;
using KouArge.Core.Models;
using KouArge.Core.Services;
using KouArge.Core.Tokens;
using KouArge.Service.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace KouArge.Service.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenHandler _tokenHandler;
        private readonly IMapper _mapper;

        public RoleService(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager, ITokenHandler tokenHandler, IMapper mapper)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _tokenHandler = tokenHandler;
            _mapper = mapper;
        }
        public async Task<CustomResponseDto<AppRole>> AddRoleAsync(AppRoleDto role)
        {
            AppRole appRole = new AppRole();
            appRole.Name = role.Name;
            IdentityResult result = await _roleManager.CreateAsync(appRole);

            if (result.Succeeded)
                return CustomResponseDto<AppRole>.Success(200, appRole);

            var error = new List<ErrorViewModel>();
            foreach (var item in result.Errors)
            {
                error.Add(new ErrorViewModel() { ErrorCode = item.Code, ErrorMessage = item.Description });
            }

            return CustomResponseDto<AppRole>.Fail(400, error);
        }


        //public async Task<CustomResponseDto<NoContentDto>> AddRoleUserAsync(AppRoleUserDto data)
        //{
        //    var user = await _userManager.FindByIdAsync(data.AppUserId);

        //    if (user == null)
        //        throw new ClientSideException("Not found");

        //    await _userManager.AddToRoleAsync(user, data.RoleName);

        //    return CustomResponseDto<NoContentDto>.Success(201);
        //}
        public async Task<CustomResponseDto<IEnumerable<AppRole>>> GetAllRolesAsync()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return CustomResponseDto<IEnumerable<AppRole>>.Success(200, roles);
        }

        public async Task<CustomResponseDto<IEnumerable<AppUserDto>>> GetUserByRoleId(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                //TODO: new Dto 
                return CustomResponseDto<IEnumerable<AppUserDto>>.Success(204);
            }
            return CustomResponseDto<IEnumerable<AppUserDto>>.Fail(400, new ErrorViewModel() { ErrorCode = "NotFound", ErrorMessage = $"Role({id} ait kullanıcı mevcut değil.)" });
        }


        public async Task<CustomResponseDto<IEnumerable<AppUserDto>>> GetUsersByRoleNameAsync(string roleName)
        {
            var role = await _userManager.GetUsersInRoleAsync(roleName);

            if (role != null)
            {
                var appuserDto = _mapper.Map<IEnumerable<AppUserDto>>(role);
                return CustomResponseDto<IEnumerable<AppUserDto>>.Success(200, appuserDto);
            }

            return CustomResponseDto<IEnumerable<AppUserDto>>.Fail(400, new ErrorViewModel() { ErrorCode = "NotFound", ErrorMessage = $"Role({roleName} ait kullanıcı mevcut değil.)" });
        }


        public async Task<CustomResponseDto<IEnumerable<StringRoleDto>>> GetRoleByUser(string token)
        {

            var decodedtoken = _tokenHandler.DecodeToken(token);
            var userId = decodedtoken.FirstOrDefault(x => x.Type == "UserId")?.Value;

            var user = await _userManager.FindByIdAsync(userId);
            var roles = await _userManager.GetRolesAsync(user);

            var roleList = new List<StringRoleDto>();

            foreach (var role in roles)
            {

                roleList.Add(new StringRoleDto() { Role = role });
            }

            if (roles != null)
            {
                //TODO: new Dto 
                return CustomResponseDto<IEnumerable<StringRoleDto>>.Success(200, roleList);
            }
            return CustomResponseDto<IEnumerable<StringRoleDto>>.Fail(400, new ErrorViewModel() { ErrorCode = "NotFound", ErrorMessage = "Beklenmeyen hata" });
        }

        //public async Task<CustomResponseDto<NoContentDto>> UpdateAsync(string id)
        //{
        //    var role = await _roleManager.FindByIdAsync(id);
        //    if (role != null)
        //    {
        //        await _roleManager.UpdateAsync(role);
        //        return CustomResponseDto<NoContentDto>.Success(204);

        //    }
        //    return CustomResponseDto<NoContentDto>.Fail(400, new ErrorViewModel() { ErrorCode = "NotFound", ErrorMessage = $"Role({id} ait kullanıcı mevcut değil.)" });

        //}


        public async Task<CustomResponseDto<NoContentDto>> AssignRoleAsync(AppRoleUserDto data)
        {
            var user = await _userManager.FindByIdAsync(data.AppUserId);

            if (user != null)
            {
                var role = await _userManager.AddToRoleAsync(user, data.RoleName);

                if (role.Succeeded)
                    return CustomResponseDto<NoContentDto>.Success(201);

               return CustomResponseDto<NoContentDto>.Fail(400, new ErrorViewModel() { ErrorCode = role.Errors.First().Code, ErrorMessage = role.Errors.First().Description });
            }

            return CustomResponseDto<NoContentDto>.Fail(400, new ErrorViewModel() { ErrorCode = "NotFound", ErrorMessage = $"Role({data.AppUserId } ait kullanıcı  mevcut değil.)" });

        }

        public async Task<CustomResponseDto<NoContentDto>> RemoveRoleUserAsync(AppRoleUserDto data)
        {
            var user = await _userManager.FindByIdAsync(data.AppUserId);

            if (user != null)
            {
                var role = await _userManager.RemoveFromRoleAsync(user, data.RoleName);

                if (role.Succeeded)
                    return CustomResponseDto<NoContentDto>.Success(200,new NoContentDto());

                return CustomResponseDto<NoContentDto>.Fail(400, new ErrorViewModel() { ErrorCode = "NotFound", ErrorMessage = $"Role({data.RoleName}  mevcut değil.)" });
            }

            return CustomResponseDto<NoContentDto>.Fail(400, new ErrorViewModel() { ErrorCode = "NotFound", ErrorMessage = $"Role({data.AppUserId} ait kullanıcı  mevcut değil.)" });

        }




        public async Task<CustomResponseDto<NoContentDto>> RemoveAsync(string id)
        {
            var role = await _roleManager.FindByNameAsync(id);
            if (role != null)
            {
                await _roleManager.DeleteAsync(role);
                return CustomResponseDto<NoContentDto>.Success(204);
            }
            return CustomResponseDto<NoContentDto>.Fail(400, new ErrorViewModel() { ErrorCode = "NotFound", ErrorMessage = $"Role({id} böyle bir rolle mevcut değil.)" });

            //await _unitOfWork.CommitAsync();
        }
    }
}
