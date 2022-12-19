using KouArge.Core.DTOs;
using KouArge.Core.Models;
using KouArge.Core.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace KouArge.Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;
        protected readonly AppIdentityDbContext _context;
        protected readonly DbSet<AppUser> _dbSet;

        public UserRepository(UserManager<AppUser> userManager, AppIdentityDbContext context)
        {
            _userManager = userManager;
            _context = context;
            _dbSet = _context.Set<AppUser>();
            _context = context;
        }

        public async Task<IEnumerable<EventParticipant>> GetAllUserEventsWithEventIdAsync(int eventId)
        {
            return await _context.EventParticipants.Include(x => x.AppUser).Where(x => x.EventId == eventId).AsNoTracking().ToListAsync();
        }

        public async Task<AppUser> GetUserDataAsync(string UserId)
        {
            return await _context.Users.Include(x => x.Department).Where(x=>x.Id==UserId).FirstOrDefaultAsync();
        }

        public async Task<AppUser> GetUserDataWithStudentNumberAsync(string studentNumber)
        {

            return await _context.Users.Where(x => x.StudentNumber == studentNumber).FirstOrDefaultAsync();
        }

        public IQueryable<Event> GetUserEventAttended(string UserId)
        {
            var data = _context.Events.Include(x => x.Speakers)
                .Where(x => x.IsActive && x.Id == x.EventParticipants.Where(t => t.AppUserId == UserId).Select(z => z.EventId).SingleOrDefault())
                .AsQueryable().AsNoTracking();

            //        var data = _context.Events.Include(x => x.Speakers).Include(x => x.EventPictures)
            //.Where(x => x.Id == x.EventParticipants.Where(t => t.AppUserId == UserId).Select(z => z.EventId).SingleOrDefault())
            //.AsQueryable().AsNoTracking();

            return data;
        }

        public async Task<IdentityResult> UpdateUser(AppUser user)
        {

            var result = await _userManager.UpdateAsync(user);
            return result;



        }

        public IQueryable<GeneralAssemblyApply> GetUserGeneralAssamblyApply(string UserId)
        {
            var data = _context.GeneralAssemblyApplies.Include(x => x.Team).Include(x => x.Title).Where(x => x.AppUserId == UserId && x.IsActive)
                .AsQueryable().AsNoTracking();

            //        var data = _context.GeneralAssemblyApplies.Include(x => x.Team).Include(x => x.Title).Where(x => x.AppUserId == UserId && x.IsActive == 1 &&
            //x.TeamId == x.Team.Id && x.TitleId == x.Title.Id).AsQueryable().AsNoTracking();
            return data;
        }

        public async Task<GeneralAssemblyApply> GetUserSingleGeneralAssamblyApplyAsync(string UserId,int AppId)
        {
            var data = await _context.GeneralAssemblyApplies.Include(x => x.Team).Include(x=>x.AppUser).Include(x => x.Title).Where(x => x.Id==AppId && x.AppUserId == UserId && x.IsActive).FirstOrDefaultAsync();

            return data;
        }

        public IQueryable<TeamMember> GetUserTeam(string UserId)
        {
            var data = _context.TeamMembers.Include(x => x.Team).Include(x => x.Title).Where(x => x.AppUserId == UserId && x.IsActive)
                .AsQueryable().AsNoTracking();

            //            var data = _context.TeamMembers.Include(x => x.Team).Include(x => x.Title).Where(x => x.AppUserId == UserId && x.IsActive == 1 &&
            //x.TeamId == x.Team.Id && x.TitleId == x.Title.Id).AsQueryable().AsNoTracking();
            return data;
        }

        public IQueryable<SocialMedia> GetUserSocialMedias(string userId)
        {
            var data = _context.SocialMedias.Include(x => x.SocaialMediaType).Include(x => x.TeamMember)
                .Where(x => x.TeamMemberId == _context.TeamMembers.Where(t => t.AppUserId == userId).Select(t => t.Id).FirstOrDefault())
                .AsQueryable().AsNoTracking();

            return data;
        }

        public IQueryable<Certificate> GetUserCertificas(string userId)
        {
            var data = _context.Certificates.Include(x => x.AppUser).Include(x => x.Event)
                .Where(x => x.AppUserId == userId).AsQueryable().AsNoTracking();

            //var data2 = _context.Users.Include(x => x.Certificates).Where(x => x.Id == userId).AsQueryable().AsNoTracking();

            return data;
        }

        public IQueryable<AppUser> GetAllUser()
        {
            return _context.Users.Include(x=>x.Department).AsQueryable(); 
        }


        //public async Task<IEnumerable<object>> GetUserGeneralAssambly(string UserId)
        //{
        //    var data = _context.GeneralAssemblies.Where(x => x.AppUserId == UserId && x.IsActive == 1).AsQueryable().AsNoTracking();
        //    return data;
        //}


        //public async Task<IEnumerable<object>> GetUserTeam(string UserId)
        //{
        //    var data = await _context.GeneralAssemblies/*.Include(x => x.TeamMembers)*/
        //        //.Where(/*x => x.Id == x.TeamMembers.Select(t => t.GeneralAssemblyId).FirstOrDefault() && x.AppUserId == UserId && x.IsActive == 1*/)
        //        .ToListAsync();



        //    return data;
        //}
    }
}
