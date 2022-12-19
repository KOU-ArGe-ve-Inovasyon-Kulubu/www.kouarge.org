using KouArge.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace KouArge.Core.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<EventParticipant>> GetAllUserEventsWithEventIdAsync(int eventId);
        Task<IdentityResult> UpdateUser(AppUser user);
        Task<AppUser> GetUserDataAsync(string UserId);
        IQueryable<Event> GetUserEventAttended(string UserId);

        IQueryable<GeneralAssemblyApply> GetUserGeneralAssamblyApply(string UserId);

        Task<GeneralAssemblyApply> GetUserSingleGeneralAssamblyApplyAsync(string UserId, int AppId);

        //Task<IEnumerable<object>> GetUserGeneralAssambly(string UserId);
        IQueryable<TeamMember> GetUserTeam(string UserId);
        IQueryable<SocialMedia> GetUserSocialMedias(string userId);
        IQueryable<Certificate> GetUserCertificas(string userId);

        IQueryable<AppUser> GetAllUser();
        Task<AppUser> GetUserDataWithStudentNumberAsync(string studentNumber);

    }
}
