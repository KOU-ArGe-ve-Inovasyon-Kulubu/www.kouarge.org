using KouArge.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Core.Services.ApiService
{
    public interface IAdminUserApiService
    {
        Task<object> DeleteUserEvent(DeleteByUserIdDto deleteDto);
        Task<CustomResponseDto<IEnumerable<EventDto>>> GetUserEventAttended(string userId);
        Task<CustomResponseDto<IEnumerable<SocialMediaDto>>> GetUserSocial(string userId);
        Task<object> DeleteUserSocial(int id);

        Task<CustomResponseDto<IEnumerable<AppUserWithTeamDto>>> GetUserTeam(string userId);
        Task<CustomResponseDto<IEnumerable<AppUserWithApplyDto>>> GetUserApply(string userId);
        Task<object> AddUserSocial(SocialMediaPostIdDto dataDto);

        Task<CustomResponseDto<AppUserDto>> GetUserWithStudentNumber(string studentNumber);
    }
}
