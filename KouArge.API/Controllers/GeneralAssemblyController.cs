using AutoMapper;
using KouArge.Core.DTOs;
using KouArge.Core.Models;
using KouArge.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace KouArge.API.Controllers
{
    public class GeneralAssemblyController : CustomBaseController
    {
        private readonly IGeneralAssemblyService _generalAssemblyService;
        private readonly IMapper _mapper;

        public GeneralAssemblyController(IGeneralAssemblyService generalAssemblyService, IMapper mapper)
        {
            _generalAssemblyService = generalAssemblyService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var generalAssembly = await _generalAssemblyService.GetAllAsync();
            var generalAssemblyDto = _mapper.Map<List<GeneralAssemblyDto>>(generalAssembly.ToList());
            return CreateActionResult(CustomResponseDto<List<GeneralAssemblyDto>>.Success(200, generalAssemblyDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var generalAssembly = await _generalAssemblyService.GetByIdAsync(id);
            var generalAssemblyDto = _mapper.Map<GeneralAssemblyDto>(generalAssembly);
            return CreateActionResult(CustomResponseDto<GeneralAssemblyDto>.Success(200, generalAssemblyDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(GeneralAssemblyDto newGeneralAssemblyDto)
        {
            var generalAssembly = await _generalAssemblyService.AddAsync(_mapper.Map<GeneralAssembly>(newGeneralAssemblyDto));
            var generalAssemblyDto = _mapper.Map<GeneralAssemblyDto>(generalAssembly);
            return CreateActionResult(CustomResponseDto<GeneralAssemblyDto>.Success(201, generalAssemblyDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(GeneralAssemblyDto newGeneralAssemblyDto)
        {
            await _generalAssemblyService.UpdateAsync(_mapper.Map<GeneralAssembly>(newGeneralAssemblyDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var generalAssembly = await _generalAssemblyService.GetByIdAsync(id);
            await _generalAssemblyService.RemoveAsync(generalAssembly);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
