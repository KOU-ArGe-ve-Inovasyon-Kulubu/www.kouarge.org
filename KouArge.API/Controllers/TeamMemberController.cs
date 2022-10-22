using AutoMapper;
using KouArge.Core.DTOs;
using KouArge.Core.Models;
using KouArge.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace KouArge.API.Controllers
{
    public class TeamMemberController : CustomBaseController
    {
        private readonly ITeamMemberService _teamMemberService;
        private readonly IMapper _mapper;

        public TeamMemberController(ITeamMemberService teamMemberService, IMapper mapper)
        {
            _teamMemberService = teamMemberService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var teamMember = await _teamMemberService.GetAllAsync();
            var teamMemberDto = _mapper.Map<List<TeamMemberDto>>(teamMember.ToList());
            return CreateActionResult(CustomResponseDto<List<TeamMemberDto>>.Success(200, teamMemberDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var teamMember = await _teamMemberService.GetByIdAsync(id);
            var teamMemberDto = _mapper.Map<TeamMemberDto>(teamMember);
            return CreateActionResult(CustomResponseDto<TeamMemberDto>.Success(200, teamMemberDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(TeamMemberDto newTeamMemberDto)
        {
            var teamMember = await _teamMemberService.AddAsync(_mapper.Map<TeamMember>(newTeamMemberDto));
            var teamMemberDto = _mapper.Map<TeamMemberDto>(teamMember);
            return CreateActionResult(CustomResponseDto<TeamMemberDto>.Success(201, teamMemberDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(TeamMemberDto newTeamMemberDto)
        {
            await _teamMemberService.UpdateAsync(_mapper.Map<TeamMember>(newTeamMemberDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var teamMember = await _teamMemberService.GetByIdAsync(id);
            await _teamMemberService.RemoveAsync(teamMember);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
