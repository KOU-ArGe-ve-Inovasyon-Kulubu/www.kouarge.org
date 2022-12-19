using AutoMapper;
using KouArge.Core.DTOs;
using KouArge.Core.DTOs.UpdateDto;
using KouArge.Core.Models;
using KouArge.Core.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KouArge.API.Controllers
{
    public class TeamController : CustomBaseController
    {
        private readonly ITeamService _teamService;
        private readonly IMapper _mapper;

        public TeamController(ITeamService teamService, IMapper mapper)
        {
            _teamService = teamService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var team = await _teamService.GetAllAsync();
            var teamDto = _mapper.Map<List<TeamDto>>(team.ToList());
            return CreateActionResult(CustomResponseDto<List<TeamDto>>.Success(200, teamDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var team = await _teamService.GetByIdAsync(id);
            var teamDto = _mapper.Map<TeamDto>(team);
            return CreateActionResult(CustomResponseDto<TeamDto>.Success(200, teamDto));
        }


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,SuperAdmin")]

        [HttpPost]
        public async Task<IActionResult> Save(TeamDto newTeamDto)
        {
            var team = await _teamService.AddAsync(_mapper.Map<Team>(newTeamDto));
            var teamDto = _mapper.Map<TeamDto>(team);
            return CreateActionResult(CustomResponseDto<TeamDto>.Success(201, teamDto));
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,SuperAdmin")]

        [HttpPut]
        public async Task<IActionResult> Update(TeamUpdateDto newTeamDto)
        {
            await _teamService.UpdateAsync(_mapper.Map<Team>(newTeamDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,SuperAdmin")]

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var team = await _teamService.GetByIdAsync(id);
            await _teamService.RemoveAsync(team);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,SuperAdmin")]

        [HttpPost("[Action]")]
        public async Task<IActionResult> SoftDeleteAsync(int id)
        {
            var team = await _teamService.GetByIdAsync(id);
            //hata dondur
            team.IsActive = false;
            await _teamService.SoftRemove(team);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

    }
}
