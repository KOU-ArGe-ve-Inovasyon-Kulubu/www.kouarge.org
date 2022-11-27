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

        [HttpGet("[Action]")]
        public async Task<IActionResult> GetAllWithDetails()
        {
            return CreateActionResult(await _socialMediaService.GetAllWithDetails());
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var socialMedias = await _socialMediaService.GetAllAsync();
            var socialMediaDto = _mapper.Map<List<SocialMediaDto>>(socialMedias.ToList());
            return CreateActionResult(CustomResponseDto<List<SocialMediaDto>>.Success(200, socialMediaDto));
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetByIdAsync(int id)
        //{
        //    var socialMedia = await _socialMediaService.GetByIdAsync(id);
        //    //hata dondur
        //    var socialMediaDto = _mapper.Map<SocialMediaDto>(socialMedia);
        //    return CreateActionResult(CustomResponseDto<SocialMediaDto>.Success(200, socialMediaDto));
        //}


        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return CreateActionResult(await _socialMediaService.GetByIdWithDetailsAsync(id));
        }


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "TeamMember,TeamManager,Admin,SuperAdmin")]

        [HttpPost]
        public async Task<IActionResult> Save(SocialMediaPostDto socialMediaDto)
        {

            await _socialMediaService.DuplicateData(socialMediaDto.SocaialMediaTypeId, socialMediaDto.Token, socialMediaDto.TeamMemberId);

            var socialMedia = await _socialMediaService.AddAsync(_mapper.Map<SocialMedia>(socialMediaDto));
            var socialMediaDtos = _mapper.Map<SocialMediaDto>(socialMedia);
            return CreateActionResult(CustomResponseDto<SocialMediaDto>.Success(201, socialMediaDtos));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "TeamMember,TeamManager,Admin,SuperAdmin")]

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(SocialMediaUpdateDto socialMediaDto)
        {
            return CreateActionResult(await _socialMediaService.UpdateAsync(socialMediaDto));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "TeamMember,TeamManager,Admin,SuperAdmin")]


        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(DeleteDto deleteDto)
        {
            return CreateActionResult(await _socialMediaService.RemoveAsync(deleteDto));
        }

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteAsync(int id)
        //{
        //    var socialMedia = await _socialMediaService.GetByIdAsync(id);
        //    //hata dondur
        //    await _socialMediaService.RemoveAsync(socialMedia);
        //    return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        //}

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,SuperAdmin")]

        [HttpPost("[Action]")]
        public async Task<IActionResult> SoftDeleteAsync(int id)
        {
            var socialMedia = await _socialMediaService.GetByIdAsync(id);
            //hata dondur
            socialMedia.IsActive = false;
            await _socialMediaService.SoftRemove(socialMedia);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

    }
}
