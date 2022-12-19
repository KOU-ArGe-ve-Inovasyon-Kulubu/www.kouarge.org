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

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Manager,Admin,SuperAdmin")]

        [HttpPost]
        public async Task<IActionResult> Save(SponsorAndPartnersDto sponsorAndPartnerDto)
        {
            var sponsorAndPartner = await _sponsorAndPartnersService.AddAsync(_mapper.Map<SponsorsAndPartners>(sponsorAndPartnerDto));
            var sponsorAndPartnerDtos = _mapper.Map<SponsorAndPartnersDto>(sponsorAndPartner);
            return CreateActionResult(CustomResponseDto<SponsorAndPartnersDto>.Success(201, sponsorAndPartnerDtos));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Manager,Admin,SuperAdmin")]

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(SponsorAndPartnersDto sponsorAndPartnerDto)
        {
            await _sponsorAndPartnersService.UpdateAsync(_mapper.Map<SponsorsAndPartners>(sponsorAndPartnerDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Manager,Admin,SuperAdmin")]

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var sponsorAndPartner = await _sponsorAndPartnersService.GetByIdAsync(id);
            //hata dondur
            await _sponsorAndPartnersService.RemoveAsync(sponsorAndPartner);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Manager,Admin,SuperAdmin")]

        [HttpPost("[Action]")]
        public async Task<IActionResult> SoftDeleteAsync(int id)
        {
            var sponsorAndPartner = await _sponsorAndPartnersService.GetByIdAsync(id);
            //hata dondur
            sponsorAndPartner.IsActive = false;
            await _sponsorAndPartnersService.SoftRemove(sponsorAndPartner);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
