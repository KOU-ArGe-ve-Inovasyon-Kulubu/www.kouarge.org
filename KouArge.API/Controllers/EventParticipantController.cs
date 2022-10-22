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
    public class EventParticipantController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IEventParticipantService _eventParticipantService;
        public EventParticipantController(IMapper mapper, IEventParticipantService eventParticipantService)
        {
            _mapper = mapper;
            _eventParticipantService = eventParticipantService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var eventParticipant = await _eventParticipantService.GetAllAsync();
            var eventParticipantDto = _mapper.Map<List<EventParticipantDto>>(eventParticipant.ToList());
            return CreateActionResult(CustomResponseDto<List<EventParticipantDto>>.Success(200, eventParticipantDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var eventParticipant = await _eventParticipantService.GetByIdAsync(id);
            //hata dondur
            var eventParticipantDto = _mapper.Map<EventParticipantDto>(eventParticipant);
            return CreateActionResult(CustomResponseDto<EventParticipantDto>.Success(200, eventParticipantDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(EventParticipantDto eventParticipantDto)
        {
            var eventParticipant = await _eventParticipantService.AddAsync(_mapper.Map<EventParticipant>(eventParticipantDto));
            var eventParticipantDtos = _mapper.Map<EventParticipantDto>(eventParticipant);
            return CreateActionResult(CustomResponseDto<EventParticipantDto>.Success(201, eventParticipantDtos));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(EventParticipantUpdateDto eventParticipantDto)
        {
            await _eventParticipantService.UpdateAsync(_mapper.Map<EventParticipant>(eventParticipantDto));
            return CreateActionResult(CustomResponseDto<EventParticipant>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var eventParticipant = await _eventParticipantService.GetByIdAsync(id);
            //hata dondur
            await _eventParticipantService.RemoveAsync(eventParticipant);
            return CreateActionResult(CustomResponseDto<EventParticipant>.Success(204));
        }
    }
}
