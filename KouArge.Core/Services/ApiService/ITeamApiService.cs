using KouArge.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Core.Services.ApiService
{
    public interface ITeamApiService
    {
        Task<CustomResponseDto<IEnumerable<TeamDto>>> GetTeamsAsync();
        Task<CustomResponseDto<TeamDto>> GetTeamByIdAsync(int id);

        Task<CustomResponseDto<TeamDto>> AddTeam(TeamDto teamDto);
        Task<CustomResponseDto<NoContentDto>> DeleteTeam(int id);
        Task<CustomResponseDto<NoContentDto>> UpdateTeam(TeamDto teadmDto);
        Task<CustomResponseDto<IEnumerable<TitleDto>>> GetAllTitles();
        Task<CustomResponseDto<TitleDto>> Addtitle(TitleDto titleDto);
        Task<CustomResponseDto<NoContentDto>> Deletetitle(int id);

    }
}
