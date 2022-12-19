using KouArge.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Core.Services.ApiService
{
    public interface ITeamMemberApiService
    {
        Task<CustomResponseDto<IEnumerable<AppUserWithTeamDto>>> GetTeamMemberDetailsAsync();
        Task<CustomResponseDto<IEnumerable<AppUserWithTeamDto>>> GetTeamMemberDetailsAsync(int id);

        Task<CustomResponseDto<TeamMemberDto>> AddTeamMember(TeamMemberDto dataDto);
        Task<CustomResponseDto<NoContentDto>> DeleteTeamMember(int id);
        Task<CustomResponseDto<AppUserWithTeamDto>> GetSingleTeamMemberAsync(int id);

        Task<CustomResponseDto<NoContentDto>> UpdateTeamMember(TeamMemberDto dataDto);
    }
}
