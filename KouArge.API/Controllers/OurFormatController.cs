using AutoMapper;
using KouArge.Core.DTOs.UpdateDto;
using KouArge.Core.DTOs;
using KouArge.Core.Models;
using KouArge.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KouArge.API.Controllers
{
    [ApiController]
    public class OurFormatController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IOurFormatService _ourFormatService;
        public OurFormatController(IMapper mapper, IOurFormatService ourFormatService)
        {
            _mapper = mapper;
            _ourFormatService = ourFormatService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var ourFormats = await _ourFormatService.GetAllAsync();
            var ourFormatsDto = _mapper.Map<List<OurFormatDto>>(ourFormats.ToList());
            return CreateActionResult(CustomResponseDto<List<OurFormatDto>>.Success(200, ourFormatsDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var ourFormat = await _ourFormatService.GetByIdAsync(id);
            //hata dondur
            var ourFormatDto = _mapper.Map<OurFormatDto>(ourFormat);
            return CreateActionResult(CustomResponseDto<OurFormatDto>.Success(200, ourFormatDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(OurFormatDto ourFormatDto)
        {
            var ourFormat = await _ourFormatService.AddAsync(_mapper.Map<OurFormat>(ourFormatDto));
            var ourFormatDtos = _mapper.Map<OurFormatDto>(ourFormat);
            return CreateActionResult(CustomResponseDto<OurFormatDto>.Success(201, ourFormatDtos));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(OurFormatUpdateDto ourFormatDto)
        {
            await _ourFormatService.UpdateAsync(_mapper.Map<OurFormat>(ourFormatDto));
            return CreateActionResult(CustomResponseDto<OurFormat>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var ourFormat = await _ourFormatService.GetByIdAsync(id);
            //hata dondur
            await _ourFormatService.RemoveAsync(ourFormat);
            return CreateActionResult(CustomResponseDto<OurFormat>.Success(204));
        }
    }
}
