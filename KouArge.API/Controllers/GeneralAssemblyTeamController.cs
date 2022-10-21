using AutoMapper;
using KouArge.Core.DTOs;
using KouArge.Core.Models;
using KouArge.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace KouArge.API.Controllers
{
    public class GeneralAssemblyTeamController : CustomBaseController
    {
        private readonly IGeneralAssemblyTeamService _generalAssemblyTeam;
        private readonly IMapper _mapper;

        public GeneralAssemblyTeamController(IGeneralAssemblyTeamService generalAssemblyTeam, IMapper mapper)
        {
            _generalAssemblyTeam = generalAssemblyTeam;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var generalAssemblyTeam = await _generalAssemblyTeam.GetAllAsync();
            var generalAssemblyTeamDto = _mapper.Map<List<GeneralAssemblyTeamDto>>(generalAssemblyTeam.ToList());
            return CreateActionResult(CustomResponseDto<List<GeneralAssemblyTeamDto>>.Success(200, generalAssemblyTeamDto));
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var generalAssemblyTeam = await _generalAssemblyTeam.GetByIdAsync(id);
            var generalAssemblyTeamDto = _mapper.Map<GeneralAssemblyTeamDto>(generalAssemblyTeam);
            return CreateActionResult(CustomResponseDto<GeneralAssemblyTeamDto>.Success(200, generalAssemblyTeamDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(GeneralAssemblyTeamDto newGeneralAssemblyTeamDto)
        {
            var generalAssemblyTeam = await _generalAssemblyTeam.AddAsync(_mapper.Map<GeneralAssemblyTeam>(newGeneralAssemblyTeamDto));
            var generalAssemblyTeamDto = _mapper.Map<GeneralAssemblyTeamDto>(generalAssemblyTeam);
            return CreateActionResult(CustomResponseDto<GeneralAssemblyTeamDto>.Success(201, generalAssemblyTeamDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(GeneralAssemblyTeamDto newGeneralAssemblyTeamDto)
        {
            await _generalAssemblyTeam.UpdateAsync(_mapper.Map<GeneralAssemblyTeam>(newGeneralAssemblyTeamDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var generalAssemblyTeam = await _generalAssemblyTeam.GetByIdAsync(id);
            await _generalAssemblyTeam.RemoveAsync(generalAssemblyTeam);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
