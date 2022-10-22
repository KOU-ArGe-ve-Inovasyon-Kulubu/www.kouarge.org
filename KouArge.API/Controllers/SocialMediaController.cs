using AutoMapper;
using KouArge.Core.DTOs;
using KouArge.Core.DTOs.UpdateDto;
using KouArge.Core.Models;
using KouArge.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KouArge.API.Controllers
{
    [ApiController]
    public class SocialMediaController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly ISocialMediaService _socialMediaService;
        public SocialMediaController(IMapper mapper, ISocialMediaService socialMediaService)
        {
            _mapper = mapper;
            _socialMediaService = socialMediaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var socialMedias = await _socialMediaService.GetAllAsync();
            var socialMediaDto = _mapper.Map<List<SocialMediaDto>>(socialMedias.ToList());
            return CreateActionResult(CustomResponseDto<List<SocialMediaDto>>.Success(200, socialMediaDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var socialMedia = await _socialMediaService.GetByIdAsync(id);
            //hata dondur
            var socialMediaDto = _mapper.Map<SocialMediaDto>(socialMedia);
            return CreateActionResult(CustomResponseDto<SocialMediaDto>.Success(200, socialMediaDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(SocialMediaDto socialMediaDto)
        {
            var socialMedia = await _socialMediaService.AddAsync(_mapper.Map<SocialMedia>(socialMediaDto));
            var socialMediaDtos = _mapper.Map<SocialMediaDto>(socialMedia);
            return CreateActionResult(CustomResponseDto<SocialMediaDto>.Success(201, socialMediaDtos));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(SocialMediaUpdateDto socialMediaDto)
        {
            await _socialMediaService.UpdateAsync(_mapper.Map<SocialMedia>(socialMediaDto));
            return CreateActionResult(CustomResponseDto<SocialMedia>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var socialMedia = await _socialMediaService.GetByIdAsync(id);
            //hata dondur
            await _socialMediaService.RemoveAsync(socialMedia);
            return CreateActionResult(CustomResponseDto<SocialMedia>.Success(204));
        }

    }
}
