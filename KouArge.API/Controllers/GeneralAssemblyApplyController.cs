using AutoMapper;
using KouArge.Core.DTOs;
using KouArge.Core.Models;
using KouArge.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace KouArge.API.Controllers
{
    public class GeneralAssemblyApplyController : CustomBaseController
    {
        private readonly IGeneralAssemblyApplyService _generalAssemblyApplyService;
        private readonly IMapper _mapper;

        public GeneralAssemblyApplyController(IGeneralAssemblyApplyService generalAssemblyApplyService, IMapper mapper)
        {
            _generalAssemblyApplyService = generalAssemblyApplyService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var generalAssemblyApply = await _generalAssemblyApplyService.GetAllAsync();
            var generalAssemblyApplyDto = _mapper.Map<List<GeneralAssemblyApplyDto>>(generalAssemblyApply.ToList());
            return CreateActionResult(CustomResponseDto<List<GeneralAssemblyApplyDto>>.Success(200, generalAssemblyApplyDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var generalAssemblyApply = await _generalAssemblyApplyService.GetByIdAsync(id);
            var generalAssemblyApplyDto = _mapper.Map<GeneralAssemblyApplyDto>(generalAssemblyApply);
            return CreateActionResult(CustomResponseDto<GeneralAssemblyApplyDto>.Success(200, generalAssemblyApplyDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(GeneralAssemblyApplyDto newGeneralAssemblyApplyDto)
        {
            var generalAssemblyApply = await _generalAssemblyApplyService.AddAsync(_mapper.Map<GeneralAssemblyApply>(newGeneralAssemblyApplyDto));
            var generalAssemblyApplyDto = _mapper.Map<GeneralAssemblyApplyDto>(generalAssemblyApply);
            return CreateActionResult(CustomResponseDto<GeneralAssemblyApplyDto>.Success(201, generalAssemblyApplyDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(GeneralAssemblyApplyDto newGeneralAssemblyApplyDto)
        {
            await _generalAssemblyApplyService.UpdateAsync(_mapper.Map<GeneralAssemblyApply>(newGeneralAssemblyApplyDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var generalAssemblyApply = await _generalAssemblyApplyService.GetByIdAsync(id);
            await _generalAssemblyApplyService.RemoveAsync(generalAssemblyApply);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
