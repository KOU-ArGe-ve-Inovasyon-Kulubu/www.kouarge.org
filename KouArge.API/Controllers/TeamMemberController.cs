using AutoMapper;
using KouArge.Core.DTOs;
using KouArge.Core.DTOs.UpdateDto;
using KouArge.Core.Models;
using KouArge.Core.Services;
using KouArge.Service.Exceptions;
using KouArge.Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KouArge.API.Controllers
{
    public class TeamMemberController : CustomBaseController
    {
        private readonly ITeamMemberService _teamMemberService;
        private readonly IMapper _mapper;
        private readonly IRoleService _roleService;
        public TeamMemberController(ITeamMemberService teamMemberService, IMapper mapper, IRoleService roleService)
        {
            _teamMemberService = teamMemberService;
            _mapper = mapper;
            _roleService = roleService;
        }


        [HttpGet("[Action]")]
        public async Task<IActionResult> GetAllWithDetails()
        {
            return CreateActionResult(await _teamMemberService.GetAllWithDetails());
        }

        [HttpGet("[Action]/{id}")]
        public async Task<IActionResult> GetAllWithDetailsId(int id)
        {
            return CreateActionResult(await _teamMemberService.GetAllWithDetails(id));
        }

        [HttpGet("[Action]/{id}")]
        public async Task<IActionResult> GetSingleDetailsById(int id)
        {
            return CreateActionResult(await _teamMemberService.GetSingleWithDetailsAsync(id));
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ReadOnly,TeamManager,Admin,SuperAdmin")]

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var teamMember = await _teamMemberService.GetAllAsync();
            var teamMemberDto = _mapper.Map<List<TeamMemberDto>>(teamMember.ToList());
            return CreateActionResult(CustomResponseDto<List<TeamMemberDto>>.Success(200, teamMemberDto));
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ReadOnly,TeamManager,Admin,SuperAdmin")]


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var teamMember = await _teamMemberService.GetByIdAsync(id);
            var teamMemberDto = _mapper.Map<TeamMemberDto>(teamMember);
            return CreateActionResult(CustomResponseDto<TeamMemberDto>.Success(200, teamMemberDto));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "TeamManager,Admin,SuperAdmin")]

        [HttpPost]
        public async Task<IActionResult> Save(TeamMemberDto teamMemberDto)
        {
            var addRole = await _roleService.AssignRoleAsync(new AppRoleUserDto() { AppUserId = teamMemberDto.AppUserId, RoleName = "TeamMember" });

            if (addRole.Errors != null)
                throw new ClientSideException("Not found");

            //Todo: Duplicate ?

            var teamMember = await _teamMemberService.AddAsync(_mapper.Map<TeamMember>(teamMemberDto));
            var teamMemberDtos = _mapper.Map<TeamMemberDto>(teamMember);
            return CreateActionResult(CustomResponseDto<TeamMemberDto>.Success(201, teamMemberDtos));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "TeamManager,Admin,SuperAdmin")]

        [HttpPut]
        public async Task<IActionResult> Update(TeamMemberUpdateDto teamMemberDto)
        {
            await _teamMemberService.UpdateAsync(_mapper.Map<TeamMember>(teamMemberDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "TeamManager,Admin,SuperAdmin")]


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var teamMember = await _teamMemberService.GetByIdAsync(id);
            await _teamMemberService.RemoveAsync(teamMember);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "TeamManager,Admin,SuperAdmin")]


        [HttpPost("[Action]")]
        public async Task<IActionResult> SoftDeleteAsync(int id)
        {
            var teamMember = await _teamMemberService.GetByIdAsync(id);
            //hata dondur
            teamMember.IsActive = false;
            await _teamMemberService.SoftRemove(teamMember);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
