using KouArge.Core.DTOs;
using KouArge.Core.Models;

namespace KouArge.Core.Services
{
    public interface ITeamMemberService : IService<TeamMember>
    {
        Task<TeamMember> GetByUserId(string userId);
        Task<CustomResponseDto<IEnumerable<AppUserWithTeamDto>>> GetAllWithDetails(int id);
        Task<CustomResponseDto<IEnumerable<AppUserWithTeamDto>>> GetAllWithDetails();
        Task DuplicateData(int teamId, string userId, int titleId);

        Task<CustomResponseDto<AppUserWithTeamDto>> GetSingleWithDetailsAsync(int id);
    }
}
