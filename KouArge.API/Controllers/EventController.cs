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
    public class EventController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IEventService _eventService;
        public EventController(IMapper mapper, IEventService eventService)
        {
            _mapper = mapper;
            _eventService = eventService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var events = await _eventService.GetAllAsync();
            var eventsDto = _mapper.Map<List<EventDto>>(events.ToList());
            return CreateActionResult(CustomResponseDto<List<EventDto>>.Success(200, eventsDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var events = await _eventService.GetByIdAsync(id);
            //hata dondur
            var eventsDto = _mapper.Map<EventDto>(events);
            return CreateActionResult(CustomResponseDto<EventDto>.Success(200, eventsDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(EventDto eventDto)
        {
            var events = await _eventService.AddAsync(_mapper.Map<Event>(eventDto));
            var eventsDto = _mapper.Map<EventDto>(events);
            return CreateActionResult(CustomResponseDto<EventDto>.Success(201, eventsDto));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(EventUpdateDto eventsDto)
        {
            await _eventService.UpdateAsync(_mapper.Map<Event>(eventsDto));
            return CreateActionResult(CustomResponseDto<Event>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var events = await _eventService.GetByIdAsync(id);
            //hata dondur
            await _eventService.RemoveAsync(events);
            return CreateActionResult(CustomResponseDto<Event>.Success(204));
        }
    }
}
