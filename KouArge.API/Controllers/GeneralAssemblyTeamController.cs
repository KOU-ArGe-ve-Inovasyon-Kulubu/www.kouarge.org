using AutoMapper;
using KouArge.Core.DTOs;
using KouArge.Core.Models;
using KouArge.Core.Services;
using KouArge.Service.Exceptions;
using KouArge.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace KouArge.API.Controllers
{
    public class GeneralAssemblyTeamController : CustomBaseController
    {
        private readonly IGeneralAssemblyTeamService _generalAssemblyTeamService;
        private readonly IMapper _mapper;

        public GeneralAssemblyTeamController(IGeneralAssemblyTeamService generalAssemblyTeamService, IMapper mapper)
        {
            _generalAssemblyTeamService = generalAssemblyTeamService;
            _mapper = mapper;
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> GetGeneralAssemblyTeamWithGeneralAssembly()
        {
            return CreateActionResult(await _generalAssemblyTeamService.GetDepartmentWithFacultyAsync());

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var generalAssemblyTeam = await _generalAssemblyTeamService.GetAllAsync();
            var generalAssemblyTeamDto = _mapper.Map<List<GeneralAssemblyTeamDto>>(generalAssemblyTeam.ToList());
            return CreateActionResult(CustomResponseDto<List<GeneralAssemblyTeamDto>>.Success(200, generalAssemblyTeamDto));
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var generalAssemblyTeam = await _generalAssemblyTeamService.GetByIdAsync(id);
            var generalAssemblyTeamDto = _mapper.Map<GeneralAssemblyTeamDto>(generalAssemblyTeam);
            return CreateActionResult(CustomResponseDto<GeneralAssemblyTeamDto>.Success(200, generalAssemblyTeamDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(GeneralAssemblyTeamDto newGeneralAssemblyTeamDto)
        {
            var generalAssemblyTeam = await _generalAssemblyTeamService.AddAsync(_mapper.Map<GeneralAssemblyTeam>(newGeneralAssemblyTeamDto));
            var generalAssemblyTeamDto = _mapper.Map<GeneralAssemblyTeamDto>(generalAssemblyTeam);
            return CreateActionResult(CustomResponseDto<GeneralAssemblyTeamDto>.Success(201, generalAssemblyTeamDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(GeneralAssemblyTeamDto newGeneralAssemblyTeamDto)
        {
            await _generalAssemblyTeamService.UpdateAsync(_mapper.Map<GeneralAssemblyTeam>(newGeneralAssemblyTeamDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var generalAssemblyTeam = await _generalAssemblyTeamService.GetByIdAsync(id);
            await _generalAssemblyTeamService.RemoveAsync(generalAssemblyTeam);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
