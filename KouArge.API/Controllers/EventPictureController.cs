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
    public class EventPictureController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IEventPictureService _eventPictureService;
        public EventPictureController(IMapper mapper, IEventPictureService eventPictureService)
        {
            _mapper = mapper;
            _eventPictureService = eventPictureService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var eventPictures = await _eventPictureService.GetAllAsync();
            var eventPicturesDto = _mapper.Map<List<EventPictureDto>>(eventPictures.ToList());
            return CreateActionResult(CustomResponseDto<List<EventPictureDto>>.Success(200, eventPicturesDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var eventPicture = await _eventPictureService.GetByIdAsync(id);
            //hata dondur
            var eventPictureDto = _mapper.Map<EventPictureDto>(eventPicture);
            return CreateActionResult(CustomResponseDto<EventPictureDto>.Success(200, eventPictureDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(EventPictureDto eventPictureDto)
        {
            var eventPicture = await _eventPictureService.AddAsync(_mapper.Map<EventPicture>(eventPictureDto));
            var eventPictureDtos = _mapper.Map<EventPictureDto>(eventPicture);
            return CreateActionResult(CustomResponseDto<EventPictureDto>.Success(201, eventPictureDtos));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(EventPictureUpdateDto eventPictureDto)
        {
            await _eventPictureService.UpdateAsync(_mapper.Map<EventPicture>(eventPictureDto));
            return CreateActionResult(CustomResponseDto<EventPicture>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var eventPicture = await _eventPictureService.GetByIdAsync(id);
            //hata dondur
            await _eventPictureService.RemoveAsync(eventPicture);
            return CreateActionResult(CustomResponseDto<EventPicture>.Success(204));
        }
    }
}
