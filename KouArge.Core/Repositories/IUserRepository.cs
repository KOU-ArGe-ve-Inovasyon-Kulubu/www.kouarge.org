using KouArge.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace KouArge.Core.Repositories
{
    public interface IUserRepository
    {
        Task<IdentityResult> UpdateUser(AppUser user);
        Task<AppUser> GetUserDataAsync(string UserId);
        IQueryable<Event> GetUserEventAttended(string UserId);

        IQueryable<GeneralAssemblyApply> GetUserGeneralAssamblyApply(string UserId);

        //Task<IEnumerable<object>> GetUserGeneralAssambly(string UserId);
        IQueryable<TeamMember> GetUserTeam(string UserId);
        IQueryable<SocialMedia> GetUserSocialMedias(string userId);
        IQueryable<Certificate> GetUserCertificas(string userId);


    }
}
