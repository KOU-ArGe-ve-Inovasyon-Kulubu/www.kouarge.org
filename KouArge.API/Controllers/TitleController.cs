using AutoMapper;
using KouArge.Core.DTOs.UpdateDto;
using KouArge.Core.DTOs;
using KouArge.Core.Models;
using KouArge.Core.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace KouArge.API.Controllers
{
 
    public class TitleController : CustomBaseController
    {

        private readonly IMapper _mapper;
        private readonly ITitleService _titleService;
        public TitleController(IMapper mapper, ITitleService titleService)
        {
            _mapper = mapper;
            _titleService = titleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var titles = await _titleService.GetAllAsync();
            var titlesDto = _mapper.Map<IEnumerable<TitleDto>>(titles.ToList());
            return CreateActionResult(CustomResponseDto<IEnumerable<TitleDto>>.Success(200, titlesDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var title = await _titleService.GetByIdAsync(id);
            //hata dondur
            var titleDto = _mapper.Map<TitleDto>(title);
            return CreateActionResult(CustomResponseDto<TitleDto>.Success(200, titleDto));
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Manager,Admin,SuperAdmin")]

        [HttpPost]
        public async Task<IActionResult> Save(TitleDto titleDto)
        {
            await _titleService.DuplicateDataAsync(titleDto.Name);
            var title = await _titleService.AddAsync(_mapper.Map<Title>(titleDto));
            var newTitleDto = _mapper.Map<TitleDto>(title);
            return CreateActionResult(CustomResponseDto<TitleDto>.Success(201, newTitleDto));
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Manager,Admin,SuperAdmin")]

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(TitleDto titleDto)
        {
            await _titleService.UpdateAsync(_mapper.Map<Title>(titleDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Manager,Admin,SuperAdmin")]

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var sponsorAndPartner = await _titleService.GetByIdAsync(id);
            //hata dondur
            await _titleService.RemoveAsync(sponsorAndPartner);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Manager,Admin,SuperAdmin")]

        [HttpPost("[Action]")]
        public async Task<IActionResult> SoftDeleteAsync(int id)
        {
            var sponsorAndPartner = await _titleService.GetByIdAsync(id);
            //hata dondur
            sponsorAndPartner.IsActive = false;
            await _titleService.SoftRemove(sponsorAndPartner);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }


    }
}
