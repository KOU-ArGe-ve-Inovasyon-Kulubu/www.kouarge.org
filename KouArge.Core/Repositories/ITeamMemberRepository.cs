using KouArge.Core.Models;

namespace KouArge.Core.Repositories
{
    public interface ITeamMemberRepository : IGenericRepository<TeamMember>
    {
        Task<TeamMember> GetByUserId(string userId, int teamMemberId);
        Task<TeamMember> GetByGeneralAssemblyApplyId(string userId, int generalAssemblyApplyId);
        Task<bool> DuplicateData(int teamId, string userId, int titleId);
        Task<TeamMember> GetByUserId(string userId);

        IQueryable<TeamMember> GetAllWithDetails(int id);
        IQueryable<TeamMember> GetAllWithDetails();

        Task<TeamMember> GetSingleWithDetailsAsync(int id);

    }
}
