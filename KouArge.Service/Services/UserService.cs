using AutoMapper;
using KouArge.Core.DTOs;
using KouArge.Core.DTOs.UpdateDto;
using KouArge.Core.Models;
using KouArge.Core.Repositories;
using KouArge.Core.Services;
using KouArge.Core.Tokens;
using KouArge.Service.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace KouArge.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly ITokenHandler _tokenHandler;


        public UserService(IUserRepository userRepository, UserManager<AppUser> userManager, IMapper mapper, ITokenHandler tokenHandler)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _mapper = mapper;
            _tokenHandler = tokenHandler;
        }

        public async Task<CustomResponseDto<AppUserDto>> GetUserDataAsync(string token)
        {
            var decodedtoken = _tokenHandler.DecodeToken(token);
            var userId = decodedtoken.FirstOrDefault(x => x.Type == "UserId")?.Value;
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                throw new NotFoundException($"{typeof(AppUser).Name}({userId}) not found.");

            var data = await _userRepository.GetUserDataAsync(user.Id);

            return CustomResponseDto<AppUserDto>.Success(200, _mapper.Map<AppUserDto>(data));
        }

        public async Task<CustomResponseDto<IEnumerable<EventDto>>> GetUserEventAttended(string token)
        {
            var decodedtoken = _tokenHandler.DecodeToken(token);
            var userId = decodedtoken.FirstOrDefault(x => x.Type == "UserId")?.Value;
            var data = await _userRepository.GetUserEventAttended(userId).ToListAsync();
            return CustomResponseDto<IEnumerable<EventDto>>.Success(200, _mapper.Map<IEnumerable<EventDto>>(data));
        }

        public async Task<CustomResponseDto<NoContentDto>> UpdateUser(AppUserUpdateDto userDto)
        {
            var decodedtoken = _tokenHandler.DecodeToken(userDto.AccessToken);
            var userId = decodedtoken.FirstOrDefault(x => x.Type == "UserId")?.Value;

            var user = await _userManager.FindByIdAsync(userId);

            var listModel = new List<ErrorViewModel>();


            if (user == null)
                return CustomResponseDto<NoContentDto>.Fail(400, new List<ErrorViewModel>() { new ErrorViewModel() { ErrorCode = "", ErrorMessage = $"{typeof(AppUser).Name}({userId}) not found." } });

            if (userDto.StudentNumber != user.StudentNumber && await _userManager.Users.FirstOrDefaultAsync(x => x.StudentNumber == userDto.StudentNumber) != null)
            {
                listModel.Add(new ErrorViewModel() { ErrorCode = "StudentNumber", ErrorMessage = $"Öğrenci numarası {userDto.StudentNumber} zaten kayıtlı." });
                //return CustomResponseDto<NoContentDto>.Fail(400, $"StudentNumber({userDto.StudentNumber}) zaten kayıtlı.", 1);
            }

            if (userDto.Email != user.Email && await _userManager.FindByEmailAsync(userDto.Email) != null)
            {
                listModel.Add(new ErrorViewModel() { ErrorCode = "Email", ErrorMessage = $"Email adresi {userDto.Email} zaten kayıtlı." });
                //return CustomResponseDto<NoContentDto>.Fail(400, $"Email({userDto.Email}) zaten kayıtlı.", 2);
            }

            if (userDto.PhoneNumber != user.PhoneNumber && await _userManager.Users.FirstOrDefaultAsync(x => x.PhoneNumber == userDto.PhoneNumber) != null)
            {
                listModel.Add(new ErrorViewModel() { ErrorCode = "PhoneNumber", ErrorMessage = $"Telefon numarası {userDto.PhoneNumber} zaten kayıtlı." });
                //return CustomResponseDto<NoContentDto>.Fail(400, $"PhoneNumber({userDto.PhoneNumber}) zaten kayıtlı.", 3);
            }

            user.Name = userDto.Name;
            user.Surname = userDto.Surname;
            user.StudentNumber = userDto.StudentNumber;
            user.Email = userDto.Email;
            user.PhoneNumber = userDto.PhoneNumber;
            user.DepartmentId = userDto.DepartmentId;
            user.Year = userDto.Year;
            user.IsActive = userDto.IsActive;
            user.NotificationId = userDto.NotificationId;

            var result = await _userRepository.UpdateUser(user);

            if (result.Succeeded)
                return CustomResponseDto<NoContentDto>.Success(204);
            else
            {
                var list = new List<string>();
                foreach (var item in result.Errors)
                {
                    listModel.Add(new ErrorViewModel() { ErrorCode = item.Code, ErrorMessage = item.Description });
                }
                return CustomResponseDto<NoContentDto>.Fail(400, listModel);
            }

        }

        //genelKurul başvuruları

        public async Task<CustomResponseDto<IEnumerable<AppUserWithApplyDto>>> GetUserGeneralAssamblyApply(string token)
        {
            var decodedtoken = _tokenHandler.DecodeToken(token);
            var userId = decodedtoken.FirstOrDefault(x => x.Type == "UserId")?.Value;
            var data = await _userRepository.GetUserGeneralAssamblyApply(userId).ToListAsync();
            return CustomResponseDto<IEnumerable<AppUserWithApplyDto>>.Success(200, _mapper.Map<IEnumerable<AppUserWithApplyDto>>(data));
        }

        public async Task<CustomResponseDto<IEnumerable<AppUserWithTeamDto>>> GetUserTeam(string token)
        {
            var decodedtoken = _tokenHandler.DecodeToken(token);
            var userId = decodedtoken.FirstOrDefault(x => x.Type == "UserId")?.Value;
            var data = await _userRepository.GetUserTeam(userId).ToListAsync();
            return CustomResponseDto<IEnumerable<AppUserWithTeamDto>>.Success(200, _mapper.Map<IEnumerable<AppUserWithTeamDto>>(data));
        }

        public async Task<CustomResponseDto<IEnumerable<SocialMediaDto>>> GetUserSocialMedias(string token)
        {
            var decodedtoken = _tokenHandler.DecodeToken(token);
            var userId = decodedtoken.FirstOrDefault(x => x.Type == "UserId")?.Value;
            var data = await _userRepository.GetUserSocialMedias(userId).ToListAsync();

            return CustomResponseDto<IEnumerable<SocialMediaDto>>.Success(200, _mapper.Map<IEnumerable<SocialMediaDto>>(data));
        }

        public async Task<CustomResponseDto<IEnumerable<AppUserWithCertificas>>> GetUserCertificas(string token)
        {
            //sertifica id sine gore.
            var decodedtoken = _tokenHandler.DecodeToken(token);
            var userId = decodedtoken.FirstOrDefault(x => x.Type == "UserId")?.Value;
            var data = await _userRepository.GetUserCertificas(userId).ToListAsync();

            return CustomResponseDto<IEnumerable<AppUserWithCertificas>>.Success(200, _mapper.Map<IEnumerable<AppUserWithCertificas>>(data));
        }
    }
}
