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
    public class GeneralAssemblyApplyController : CustomBaseController
    {
        private readonly IGeneralAssemblyApplyService _generalAssemblyApplyService;
        private readonly IMapper _mapper;
        private readonly ITeamMemberService _teamMemberService;

        public GeneralAssemblyApplyController(IGeneralAssemblyApplyService generalAssemblyApplyService, IMapper mapper, ITeamMemberService teamMemberService)
        {
            _generalAssemblyApplyService = generalAssemblyApplyService;
            _mapper = mapper;
            _teamMemberService = teamMemberService;
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ReadOnly,TeamManager,Admin,SuperAdmin")]

        [HttpGet("[Action]")]
        public async Task<IActionResult> GetAllWithUser()
        {
            return CreateActionResult(await _generalAssemblyApplyService.GetAllWithUserAsync());
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var generalAssemblyApply = await _generalAssemblyApplyService.GetAllAsync();
            var generalAssemblyApplyDto = _mapper.Map<List<GeneralAssemblyApplyDto>>(generalAssemblyApply.ToList());
            return CreateActionResult(CustomResponseDto<List<GeneralAssemblyApplyDto>>.Success(200, generalAssemblyApplyDto));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(DeleteDto dto)
        {
            //DeleteDto id ve Token var.
            return CreateActionResult(await _generalAssemblyApplyService.GetByUserId(dto.Id, dto.Token));
        }


        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    var generalAssemblyApply = await _generalAssemblyApplyService.GetByIdAsync(id);
        //    var generalAssemblyApplyDto = _mapper.Map<GeneralAssemblyApplyDto>(generalAssemblyApply);
        //    return CreateActionResult(CustomResponseDto<GeneralAssemblyApplyDto>.Success(200, generalAssemblyApplyDto));
        //}

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        [HttpPost]
        public async Task<IActionResult> Save(GeneralAssemblyApplyDto generalAssemblyApplyDto)
        {
            await _generalAssemblyApplyService.DuplicateData(generalAssemblyApplyDto.TeamId, generalAssemblyApplyDto.AppUserId, generalAssemblyApplyDto.TitleId);

            return CreateActionResult(await _generalAssemblyApplyService.AddAsync(generalAssemblyApplyDto.Token, _mapper.Map<GeneralAssemblyApply>(generalAssemblyApplyDto)));
        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> SaveWithId(GeneralAssemblyApplyDto generalAssemblyApplyDto)
        {
            await _generalAssemblyApplyService.DuplicateData(generalAssemblyApplyDto.TeamId, generalAssemblyApplyDto.AppUserId, generalAssemblyApplyDto.TitleId);

            return CreateActionResult(await _generalAssemblyApplyService.AddAsync(_mapper.Map<GeneralAssemblyApply>(generalAssemblyApplyDto)));
        }

        //[HttpPost]
        //public async Task<IActionResult> Save(GeneralAssemblyApplyDto newGeneralAssemblyApplyDto)
        //{
        //    var generalAssemblyApply = await _generalAssemblyApplyService.AddAsync(_mapper.Map<GeneralAssemblyApply>(newGeneralAssemblyApplyDto));
        //    var generalAssemblyApplyDto = _mapper.Map<GeneralAssemblyApplyDto>(generalAssemblyApply);
        //    return CreateActionResult(CustomResponseDto<GeneralAssemblyApplyDto>.Success(201, generalAssemblyApplyDto));
        //}

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "TeamManager,Admin,SuperAdmin")]

        [HttpPut]
        public async Task<IActionResult> Update(GeneralAssemblyApplyUpdateDto newGeneralAssemblyApplyDto)
        {
            await _generalAssemblyApplyService.UpdateAsync(_mapper.Map<GeneralAssemblyApply>(newGeneralAssemblyApplyDto));

            TeamMember teamMember;
            if (newGeneralAssemblyApplyDto.AppStatus == 1)
            {

                var data = await _teamMemberService.GetByUserId(newGeneralAssemblyApplyDto.AppUserId);

                if (data == null)
                {
                    teamMember = new TeamMember()
                    {
                        AppUserId = newGeneralAssemblyApplyDto.AppUserId,
                        GeneralAssemblyApplyId = newGeneralAssemblyApplyDto.Id,
                        TeamId = newGeneralAssemblyApplyDto.TeamId,
                        TitleId = newGeneralAssemblyApplyDto.TitleId,
                        IsActive = true,
                        StartDate = DateTime.Now,
                        ImgUrl = "",
                    };
                    await _teamMemberService.AddAsync(teamMember);
                }

            }
            else if(newGeneralAssemblyApplyDto.AppStatus == 2)
            {
                var data = await _teamMemberService.GetByUserId(newGeneralAssemblyApplyDto.AppUserId);

                if (data != null)
                {
                    await _teamMemberService.RemoveAsync(data);
                }
            }


            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteDto deleteDto)
        {
            return CreateActionResult(await _generalAssemblyApplyService.RemoveAsync(deleteDto));
        }

        [HttpDelete("[Action]/{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            return CreateActionResult(await _generalAssemblyApplyService.RemoveByIdAsync(id));
        }

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(DeleteDto deleteDto)
        //{
        //    var generalAssemblyApply = await _generalAssemblyApplyService.GetByIdAsync(deleteDto.Id);
        //    await _generalAssemblyApplyService.RemoveAsync(generalAssemblyApply);
        //    return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        //}

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,SuperAdmin")]

        [HttpPost("[Action]")]
        public async Task<IActionResult> SoftDeleteAsync(int id)
        {
            var generalAssemblyApply = await _generalAssemblyApplyService.GetByIdAsync(id);
            //hata dondur
            generalAssemblyApply.IsActive = false;
            await _generalAssemblyApplyService.SoftRemove(generalAssemblyApply);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
