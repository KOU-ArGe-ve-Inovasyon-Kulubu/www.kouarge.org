using AutoMapper;
using KouArge.Core.DTOs;
using KouArge.Core.Models;
using KouArge.Core.Services;
using KouArge.Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace KouArge.API.Controllers
{
    public class SpeakerController : CustomBaseController
    {
        private readonly ISpeakerService _speakerService;
        private readonly IMapper _mapper;

        public SpeakerController(ISpeakerService speakerService, IMapper mapper)
        {
            _speakerService = speakerService;
            _mapper = mapper;
        }


        [HttpGet("[Action]/{eventId}")]
        public async Task<IActionResult> GetAllByEventIdAsync(int eventId)
        {
            return CreateActionResult(await _speakerService.GetAllByEventIdAsync(eventId));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var speakers = await _speakerService.GetAllAsync();
            var speakersDto = _mapper.Map<List<SpeakerDto>>(speakers.ToList());
            return CreateActionResult(CustomResponseDto<List<SpeakerDto>>.Success(200, speakersDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var speakers = await _speakerService.GetByIdAsync(id);
            //hata dondur
            var speakersDto = _mapper.Map<SpeakerDto>(speakers);
            return CreateActionResult(CustomResponseDto<SpeakerDto>.Success(200, speakersDto));
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Manager,Admin,SuperAdmin")]

        [HttpPost]
        public async Task<IActionResult> Save(SpeakerDto speakerDto)
        {
            var speaker = await _speakerService.AddAsync(_mapper.Map<Speaker>(speakerDto));
            var speakerDtos = _mapper.Map<SpeakerDto>(speaker);
            return CreateActionResult(CustomResponseDto<SpeakerDto>.Success(201, speakerDtos));
        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> AddRange(List<SpeakerDto> speakersDto)
        {
            var speaker = await _speakerService.AddRangeAsync(_mapper.Map<List<Speaker>>(speakersDto));
            var speakerDtos = _mapper.Map<List<SpeakerDto>>(speaker);
            return CreateActionResult(CustomResponseDto<List<SpeakerDto>>.Success(201, speakerDtos));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Manager,Admin,SuperAdmin")]

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(SpeakerDto speakerDto)
        {
            await _speakerService.UpdateAsync(_mapper.Map<Speaker>(speakerDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Manager,Admin,SuperAdmin")]

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var speaker = await _speakerService.GetByIdAsync(id);
            await _speakerService.RemoveAsync(speaker);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Manager,Admin,SuperAdmin")]

        [HttpPost("[Action]")]
        public async Task<IActionResult> SoftDeleteAsync(int id)
        {
            var speaker = await _speakerService.GetByIdAsync(id);
            //hata dondur
            speaker.IsActive = false;
            await _speakerService.SoftRemove(speaker);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }





    }
}
