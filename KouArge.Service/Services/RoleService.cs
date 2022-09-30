using KouArge.Core.DTOs;
using KouArge.Core.Models;
using KouArge.Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Service.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleService(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<CustomResponseDto<AppRole>> AddRoleAsync(AppRoleDto role)
        {
            AppRole appRole = new AppRole();
            appRole.Name = role.Name;
            IdentityResult result = await _roleManager.CreateAsync(appRole);

            if (result.Succeeded)
                return CustomResponseDto<AppRole>.Success(200, appRole);

            var error = new List<string>();
            foreach (var item in result.Errors)
            {
                error.Add(item.Description);
            }

            return CustomResponseDto<AppRole>.Fail(400, error);
        }

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
            return CustomResponseDto<IEnumerable<AppUserDto>>.Fail(400, $"Role({id} ait kullanıcı mevcut değil.)");
        }

        public async Task<CustomResponseDto<NoContentDto>> RemoveAsync(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                await _roleManager.DeleteAsync(role);
                return CustomResponseDto<NoContentDto>.Success(204);
            }
            return CustomResponseDto<NoContentDto>.Fail(400,$"Role({id} böyle bir rolle mevcut değil.)");
            //await _unitOfWork.CommitAsync();
        }
    }
}
