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
    public class SocialMediaTypeController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly ISocialMediaTypeService _socialMediaTypeService;
        public SocialMediaTypeController(IMapper mapper, ISocialMediaTypeService socialMediaTypeService)
        {
            _mapper = mapper;
            _socialMediaTypeService = socialMediaTypeService;
        }



        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var socialMediaTypes = await _socialMediaTypeService.GetAllAsync();
            var socialMediaTypeDto = _mapper.Map<List<SocialMediaTypeDto>>(socialMediaTypes.ToList());
            return CreateActionResult(CustomResponseDto<List<SocialMediaTypeDto>>.Success(200, socialMediaTypeDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var socialMediaType = await _socialMediaTypeService.GetByIdAsync(id);
            //hata dondur
            var socialMediaTypeDto = _mapper.Map<SocialMediaTypeDto>(socialMediaType);
            return CreateActionResult(CustomResponseDto<SocialMediaTypeDto>.Success(200, socialMediaTypeDto));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Manager,TeamMember,TeamManager,Admin,SuperAdmin")]


        [HttpPost]
        public async Task<IActionResult> Save(SocialMediaTypeDto socialMediaTypeDto)
        {
            var socialMediaType = await _socialMediaTypeService.AddAsync(_mapper.Map<SocialMediaType>(socialMediaTypeDto));
            var socialMediaTypeDtos = _mapper.Map<SocialMediaTypeDto>(socialMediaType);
            return CreateActionResult(CustomResponseDto<SocialMediaTypeDto>.Success(201, socialMediaTypeDtos));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Manager,TeamManager,Admin,SuperAdmin")]


        [HttpPut]
        public async Task<IActionResult> UpdateAsync(SocialMediaTypeUpdateDto socialMediaTypeDto)
        {
            await _socialMediaTypeService.UpdateAsync(_mapper.Map<SocialMediaType>(socialMediaTypeDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Manager,TeamManager,Admin,SuperAdmin")]


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var socialMediaType = await _socialMediaTypeService.GetByIdAsync(id);
            //hata dondur
            await _socialMediaTypeService.RemoveAsync(socialMediaType);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Manager,TeamManager,Admin,SuperAdmin")]

        [HttpPost("[Action]")]
        public async Task<IActionResult> SoftDeleteAsync(int id)
        {
            var socialMediaType = await _socialMediaTypeService.GetByIdAsync(id);
            //hata dondur
            socialMediaType.IsActive = false;
            await _socialMediaTypeService.SoftRemove(socialMediaType);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
