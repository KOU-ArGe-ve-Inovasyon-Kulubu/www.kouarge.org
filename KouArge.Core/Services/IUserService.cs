using KouArge.Core.DTOs;
using KouArge.Core.DTOs.UpdateDto;

namespace KouArge.Core.Services
{
    public interface IUserService
    {
        Task<CustomResponseDto<NoContentDto>> UpdateUser(AppUserUpdateDto user);
        Task<CustomResponseDto<AppUserDto>> GetUserDataAsync(string token);//TODO : datalar
        Task<CustomResponseDto<IEnumerable<EventDto>>> GetUserEventAttended(string token);//TODO: yeni Dto yap.
        Task<CustomResponseDto<IEnumerable<AppUserWithApplyDto>>> GetUserGeneralAssamblyApply(string token);
        Task<CustomResponseDto<IEnumerable<AppUserWithTeamDto>>> GetUserTeam(string token);
        Task<CustomResponseDto<IEnumerable<SocialMediaDto>>> GetUserSocialMedias(string token);
        Task<CustomResponseDto<IEnumerable<AppUserWithCertificas>>> GetUserCertificas(string token);

    }
}
