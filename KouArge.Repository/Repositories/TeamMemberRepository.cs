using KouArge.Core.Models;
using KouArge.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KouArge.Repository.Repositories
{
    public class TeamMemberRepository : GenericRepository<TeamMember>, ITeamMemberRepository
    {
        public TeamMemberRepository(AppIdentityDbContext context) : base(context)
        {
        }

        public async Task<TeamMember> GetByUserId(string userId, int teamMemberId)
        {
            return await _context.TeamMembers.FirstOrDefaultAsync(x => x.Id == teamMemberId && x.AppUserId == userId);
        }

        public async Task<TeamMember> GetByUserId(string userId)
        {
            return await _context.TeamMembers.FirstOrDefaultAsync(x => x.AppUserId == userId);

        }
        public async Task<TeamMember> GetByGeneralAssemblyApplyId(string userId, int generalAssemblyApplyId)
        {
            return await _context.TeamMembers.FirstOrDefaultAsync(x => x.GeneralAssemblyApplyId == generalAssemblyApplyId && x.AppUserId == userId);
        }

        public IQueryable<TeamMember> GetAllWithDetails(int id)
        {
            return _context.TeamMembers.Include(x => x.Team).Include(x => x.Title).Include(x => x.AppUser).Where(x => x.TeamId == id).AsQueryable().AsNoTracking();
        }

        public async Task<TeamMember> GetSingleWithDetailsAsync(int id)
        {
            return await _context.TeamMembers.Include(x => x.Team).Include(x => x.Title).Include(x => x.AppUser).Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public IQueryable<TeamMember> GetAllWithDetails()
        {
            return _context.TeamMembers.Include(x => x.Team).Include(x => x.Title).Include(x => x.AppUser).AsQueryable().AsNoTracking();
        }

        public async Task<bool> DuplicateData(int teamId, string userId, int titleId)
        {
            return await _context.GeneralAssemblyApplies.AnyAsync(x => x.TeamId == teamId && x.AppUserId == userId && x.TitleId == titleId && x.IsActive == true);
        }
    }
}
