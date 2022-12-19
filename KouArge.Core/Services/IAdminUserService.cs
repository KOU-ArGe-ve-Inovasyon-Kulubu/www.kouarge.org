using KouArge.Core.DTOs;
using KouArge.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Core.Services
{
    public interface IAdminUserService
    {
        Task<CustomResponseDto<IEnumerable<EventParticipantWithUserDto>>> GetAllUserEventByEventId(int eventId);
        Task<CustomResponseDto<IEnumerable<AppUserWithApplyDto>>> GetUserGeneralAssamblyApply(string userId);
        Task<CustomResponseDto<IEnumerable<AppUserWithTeamDto>>> GetUserTeam(string userId);
        Task<CustomResponseDto<IEnumerable<SocialMediaDto>>> GetUserSocialMedias(string userId);
        Task<CustomResponseDto<IEnumerable<AppUserWithCertificas>>> GetUserCertificas(string userId);
        Task<CustomResponseDto<IEnumerable<EventDto>>> GetUserEvent(string userId);
        Task<CustomResponseDto<AppUserDto>> GetUserWithStudentNumberAsync(string studentNumber);
        Task<CustomResponseDto<GeneralAssemblyApplyWithUserDto>> GetUserSingleGeneralAssamblyApply(string userId, int appId);

    }
}
