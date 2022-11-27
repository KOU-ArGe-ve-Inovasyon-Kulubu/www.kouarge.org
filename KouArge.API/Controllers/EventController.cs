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
    public class EventController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IEventService _eventService;
        public EventController(IMapper mapper, IEventService eventService)
        {
            _mapper = mapper;
            _eventService = eventService;
        }

        [AllowAnonymous]
        [HttpGet("[Action]")]
        public async Task<IActionResult> GetAllWithDetails()
        {
            return CreateActionResult(await _eventService.GetAllWithDetails());
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var events = await _eventService.GetAllAsync();
            var eventsOrder = events.OrderByDescending(x => x.EventDate);
            var eventsDto = _mapper.Map<List<EventDto>>(eventsOrder.ToList());
            return CreateActionResult(CustomResponseDto<List<EventDto>>.Success(200, eventsDto));
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return CreateActionResult(await _eventService.GetByIdWithDetailsAsync(id));
        }


        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetByIdAsync(int id)
        //{
        //    var events = await _eventService.GetByIdAsync(id);
        //    //hata dondur
        //    var eventsDto = _mapper.Map<EventDto>(events);
        //    return CreateActionResult(CustomResponseDto<EventDto>.Success(200, eventsDto));
        //}


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Manager,Admin,SuperAdmin")]


        [HttpPost]
        public async Task<IActionResult> Save(EventDto eventDto)
        {
            var events = await _eventService.AddAsync(_mapper.Map<Event>(eventDto));
            var eventsDto = _mapper.Map<EventDto>(events);
            return CreateActionResult(CustomResponseDto<EventDto>.Success(201, eventsDto));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Manager,Admin,SuperAdmin")]

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(EventUpdateDto eventsDto)
        {
            await _eventService.UpdateAsync(_mapper.Map<Event>(eventsDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Manager,Admin,SuperAdmin")]

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var events = await _eventService.GetByIdAsync(id);
            //hata dondur
            await _eventService.RemoveAsync(events);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Manager,Admin,SuperAdmin")]

        [HttpPost("[Action]")]
        public async Task<IActionResult> SoftDeleteAsync(int id)
        {
            var events = await _eventService.GetByIdAsync(id);
            //hata dondur
            events.IsActive = false;
            await _eventService.SoftRemove(events);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
