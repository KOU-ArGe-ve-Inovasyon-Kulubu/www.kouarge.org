using KouArge.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Core.Repositories
{
    public interface IAdminUserRepository
    {
        public IQueryable<Event> GetUserEventAttended(string UserId);
        public IQueryable<GeneralAssemblyApply> GetUserGeneralAssamblyApply(string UserId);
        public IQueryable<TeamMember> GetUserTeam(string UserId);
        public IQueryable<SocialMedia> GetUserSocialMedias(string userId);
        public IQueryable<Certificate> GetUserCertificas(string userId);
    }
}
