using AutoMapper;
using KouArge.Core.DTOs;
using KouArge.Core.DTOs.UpdateDto;
using KouArge.Core.Models;
using KouArge.Core.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ReadOnly,Admin,SuperAdmin")]

        [HttpGet("[Action]/{eventId}")]
        public async Task<IActionResult> GetAllByEventIdAsync(int eventId)
        {
            return CreateActionResult(await _eventParticipantService.GetAllByEventIdAsync(eventId));
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var eventParticipant = await _eventParticipantService.GetAllAsync();
            var eventParticipantDto = _mapper.Map<List<EventParticipantDto>>(eventParticipant.ToList());
            return CreateActionResult(CustomResponseDto<List<EventParticipantDto>>.Success(200, eventParticipantDto));
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ReadOnly,Admin,SuperAdmin")]

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var eventParticipant = await _eventParticipantService.GetByIdAsync(id);
            //hata dondur
            var eventParticipantDto = _mapper.Map<EventParticipantDto>(eventParticipant);
            return CreateActionResult(CustomResponseDto<EventParticipantDto>.Success(200, eventParticipantDto));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<IActionResult> Save(EventParticipantDto eventParticipantDto)
        {
            await _eventParticipantService.DuplicateData(eventParticipantDto.EventId, eventParticipantDto.AppUserId);
            return CreateActionResult(await _eventParticipantService.AddAsync(eventParticipantDto.Token, _mapper.Map<EventParticipant>(eventParticipantDto)));
        }

        //[HttpPost]
        //public async Task<IActionResult> Save(EventParticipantDto eventParticipantDto)
        //{
        //    await _eventParticipantService.DuplicateData(eventParticipantDto.EventId, eventParticipantDto.AppUserId);

        //    var eventParticipant = await _eventParticipantService.AddAsync(_mapper.Map<EventParticipant>(eventParticipantDto));
        //    var eventParticipantDtos = _mapper.Map<EventParticipantDto>(eventParticipant);
        //    return CreateActionResult(CustomResponseDto<EventParticipantDto>.Success(201, eventParticipantDtos));

        //}

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,SuperAdmin")]

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(EventParticipantUpdateDto eventParticipantDto)
        {
            await _eventParticipantService.UpdateAsync(_mapper.Map<EventParticipant>(eventParticipantDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(DeleteDto deleteDto)
        {
            return CreateActionResult(await _eventParticipantService.RemoveAsync(deleteDto));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,SuperAdmin")]

        [HttpDelete("[Action]/{eventId}/{userId}")]
        public async Task<IActionResult> DeleteByUserIdAsync(int eventId, string userId)
        {
            return CreateActionResult(await _eventParticipantService.RemoveByUserIdAsync(new DeleteByUserIdDto() { Id=eventId,UserId=userId}));
        }

        [HttpDelete("[Action]/{id}")]
        public async Task<IActionResult> DeleteByIdAsync(int id)
        {
            return CreateActionResult(await _eventParticipantService.RemoveByIdAsync(id));

        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,SuperAdmin")]

        [HttpPost("[Action]")]
        public async Task<IActionResult> SoftDeleteAsync(int id)
        {
            var eventParticipant = await _eventParticipantService.GetByIdAsync(id);
            //hata dondur
            eventParticipant.IsActive = false;
            await _eventParticipantService.SoftRemove(eventParticipant);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
