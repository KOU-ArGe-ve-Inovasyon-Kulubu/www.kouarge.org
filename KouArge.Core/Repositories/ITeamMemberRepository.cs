using KouArge.Core.Models;

namespace KouArge.Core.Repositories
{
    public interface ITeamMemberRepository : IGenericRepository<TeamMember>
    {
        Task<TeamMember> GetByUserId(string userId, int teamMemberId);
        Task<TeamMember> GetByGeneralAssemblyApplyId(string userId, int generalAssemblyApplyId);
    }
}
