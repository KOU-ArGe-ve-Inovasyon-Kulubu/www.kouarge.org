using AutoMapper;
using KouArge.Core.DTOs;
using KouArge.Core.Models;
using KouArge.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace KouArge.API.Controllers
{
    public class GeneralAssemblyApplyController : CustomBaseController
    {
        private readonly IGeneralAssemblyApplyService _generalAssemblyApply;
        private readonly IMapper _mapper;

        public GeneralAssemblyApplyController(IGeneralAssemblyApplyService generalAssemblyApply, IMapper mapper)
        {
            _generalAssemblyApply = generalAssemblyApply;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var generalAssemblyApply = await _generalAssemblyApply.GetAllAsync();
            var generalAssemblyApplyDto = _mapper.Map<List<GeneralAssemblyApplyDto>>(generalAssemblyApply.ToList());
            return CreateActionResult(CustomResponseDto<List<GeneralAssemblyApplyDto>>.Success(200, generalAssemblyApplyDto));
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var generalAssemblyApply = await _generalAssemblyApply.GetByIdAsync(id);
            var generalAssemblyApplyDto = _mapper.Map<GeneralAssemblyApplyDto>(generalAssemblyApply);
            return CreateActionResult(CustomResponseDto<GeneralAssemblyApplyDto>.Success(200, generalAssemblyApplyDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(GeneralAssemblyApplyDto newGeneralAssemblyApplyDto)
        {
            var generalAssemblyApply = await _generalAssemblyApply.AddAsync(_mapper.Map<GeneralAssemblyApply>(newGeneralAssemblyApplyDto));
            var generalAssemblyApplyDto = _mapper.Map<GeneralAssemblyApplyDto>(generalAssemblyApply);
            return CreateActionResult(CustomResponseDto<GeneralAssemblyApplyDto>.Success(201, generalAssemblyApplyDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(GeneralAssemblyApplyDto newGeneralAssemblyApplyDto)
        {
            await _generalAssemblyApply.UpdateAsync(_mapper.Map<GeneralAssemblyApply>(newGeneralAssemblyApplyDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var generalAssemblyApply = await _generalAssemblyApply.GetByIdAsync(id);
            await _generalAssemblyApply.RemoveAsync(generalAssemblyApply);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
