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

        public async Task<TeamMember> GetByGeneralAssemblyApplyId(string userId, int generalAssemblyApplyId)
        {
            return await _context.TeamMembers.FirstOrDefaultAsync(x => x.GeneralAssemblyApplyId == generalAssemblyApplyId && x.AppUserId == userId);
        }
    }
}
