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
    public class EventPictureController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IEventPictureService _eventPictureService;
        public EventPictureController(IMapper mapper, IEventPictureService eventPictureService)
        {
            _mapper = mapper;
            _eventPictureService = eventPictureService;
        }

        [AllowAnonymous]

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var eventPictures = await _eventPictureService.GetAllAsync();
            var eventPicturesDto = _mapper.Map<List<EventPictureDto>>(eventPictures.ToList());
            return CreateActionResult(CustomResponseDto<List<EventPictureDto>>.Success(200, eventPicturesDto));
        }


        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var eventPicture = await _eventPictureService.GetByIdAsync(id);
            //hata dondur
            var eventPictureDto = _mapper.Map<EventPictureDto>(eventPicture);
            return CreateActionResult(CustomResponseDto<EventPictureDto>.Success(200, eventPictureDto));
        }

        [AllowAnonymous]
        [HttpGet("[Action]")]
        public async Task<IActionResult> GetByEventIdAsync(int eventId)
        {
            var eventPicture = await _eventPictureService.GetByEventId(eventId);
            //hata dondur
            var eventPictureDto = _mapper.Map<IEnumerable<EventPictureDto>>(eventPicture);
            return CreateActionResult(CustomResponseDto<IEnumerable<EventPictureDto>>.Success(200, eventPictureDto));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Manager,Admin,SuperAdmin")]

        [HttpPost]
        public async Task<IActionResult> Save(EventPictureDto eventPictureDto)
        {
            var eventPicture = await _eventPictureService.AddAsync(_mapper.Map<EventPicture>(eventPictureDto));
            var eventPictureDtos = _mapper.Map<EventPictureDto>(eventPicture);
            return CreateActionResult(CustomResponseDto<EventPictureDto>.Success(201, eventPictureDtos));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Manager,Admin,SuperAdmin")]


        [HttpPost("[Action]")]
        public async Task<IActionResult> SaveRange(IEnumerable<EventPictureDto> eventPictureDto)
        {
            var eventPicture = await _eventPictureService.AddRangeAsync(_mapper.Map<IEnumerable<EventPicture>>(eventPictureDto));
            var eventPictureDtos = _mapper.Map<IEnumerable<EventPictureDto>>(eventPicture);
            return CreateActionResult(CustomResponseDto<IEnumerable<EventPictureDto>>.Success(201, eventPictureDtos));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Manager,Admin,SuperAdmin")]

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(EventPictureUpdateDto eventPictureDto)
        {
            await _eventPictureService.UpdateAsync(_mapper.Map<EventPicture>(eventPictureDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Manager,Admin,SuperAdmin")]


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var eventPicture = await _eventPictureService.GetByIdAsync(id);
            //hata dondur
            await _eventPictureService.RemoveAsync(eventPicture);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Manager,Admin,SuperAdmin")]

        [HttpPost("[Action]")]
        public async Task<IActionResult> SoftDeleteAsync(int id)
        {
            var eventPicture = await _eventPictureService.GetByIdAsync(id);
            //hata dondur
            eventPicture.IsActive = false;
            await _eventPictureService.SoftRemove(eventPicture);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
