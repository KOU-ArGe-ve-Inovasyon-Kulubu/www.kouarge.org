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
    public class SponsorAndPartnersController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly ISponsorAndPartnersService _sponsorAndPartnersService;
        public SponsorAndPartnersController(IMapper mapper, ISponsorAndPartnersService sponsorAndPartnersService)
        {
            _mapper = mapper;
            _sponsorAndPartnersService = sponsorAndPartnersService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var sponsorAndPartners = await _sponsorAndPartnersService.GetAllAsync();
            var sponsorAndPartnersDto = _mapper.Map<List<SponsorAndPartnersDto>>(sponsorAndPartners.ToList());
            return CreateActionResult(CustomResponseDto<List<SponsorAndPartnersDto>>.Success(200, sponsorAndPartnersDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var sponsorAndPartner = await _sponsorAndPartnersService.GetByIdAsync(id);
            //hata dondur
            var sponsorAndPartnerDto = _mapper.Map<SponsorAndPartnersDto>(sponsorAndPartner);
            return CreateActionResult(CustomResponseDto<SponsorAndPartnersDto>.Success(200, sponsorAndPartnerDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(SponsorAndPartnersDto sponsorAndPartnerDto)
        {
            var sponsorAndPartner = await _sponsorAndPartnersService.AddAsync(_mapper.Map<SponsorsAndPartners>(sponsorAndPartnerDto));
            var sponsorAndPartnerDtos = _mapper.Map<SponsorAndPartnersDto>(sponsorAndPartner);
            return CreateActionResult(CustomResponseDto<SponsorAndPartnersDto>.Success(201, sponsorAndPartnerDtos));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(SponsorAndPartnersUpdateDto sponsorAndPartnerDto)
        {
            await _sponsorAndPartnersService.UpdateAsync(_mapper.Map<SponsorsAndPartners>(sponsorAndPartnerDto));
            return CreateActionResult(CustomResponseDto<SponsorsAndPartners>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var sponsorAndPartner = await _sponsorAndPartnersService.GetByIdAsync(id);
            //hata dondur
            await _sponsorAndPartnersService.RemoveAsync(sponsorAndPartner);
            return CreateActionResult(CustomResponseDto<SponsorsAndPartners>.Success(204));
        }
    }
}
