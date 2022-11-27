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

    public class CertificateController : CustomBaseController
    {
        private readonly ICertificateService _certificateService;
        private readonly IMapper _mapper;
        public CertificateController(ICertificateService certificateService, IMapper mapper)
        {
            _certificateService = certificateService;
            _mapper = mapper;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ReadOnly,Admin,SuperAdmin")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var certificates = await _certificateService.GetAllAsync();

            var certificatesDto = _mapper.Map<List<CertificateDto>>(certificates.ToList());
            return CreateActionResult(CustomResponseDto<List<CertificateDto>>.Success(200, certificatesDto));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ReadOnly,Admin,SuperAdmin")]
        [HttpGet("[Action]")]
        public async Task<IActionResult> GetAllWithDetails()
        {
            return CreateActionResult(await _certificateService.GetAllWithDetails());
        }

        [AllowAnonymous]
        [HttpGet("[Action]/{id}")]
        public async Task<IActionResult> GetByIdWithDetailsAsync(string id)
        {
            var certificates = await _certificateService.GetByIdWithDetailsAsync(id);
            //hata dondur
            var certificatesDto = _mapper.Map<AppUserWithCertificas>(certificates);
            return CreateActionResult(CustomResponseDto<AppUserWithCertificas>.Success(200, certificatesDto));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ReadOnly,Admin,SuperAdmin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            var certificates = await _certificateService.GetByIdAsync(id);
            //hata dondur
            var certificatesDto = _mapper.Map<CertificateDto>(certificates);
            return CreateActionResult(CustomResponseDto<CertificateDto>.Success(200, certificatesDto));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        [HttpPost]
        public async Task<IActionResult> Save(CertificateDto certificateDto)
        {
            await _certificateService.DuplicateData(certificateDto.EventId, certificateDto.AppUserId);
            return CreateActionResult(await _certificateService.AddAsync(certificateDto.Token, _mapper.Map<Certificate>(certificateDto)));
        }


        //public async Task<IActionResult> Save(CertificateDto certificateDto)
        //{
        //    await _certificateService.DuplicateData(certificateDto.EventId, certificateDto.AppUserId);

        //    var certificate = await _certificateService.AddAsync(_mapper.Map<Certificate>(certificateDto));
        //    var certificatesDto = _mapper.Map<CertificateDto>(certificate);
        //    return CreateActionResult(CustomResponseDto<CertificateDto>.Success(201, certificatesDto));
        //}


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,SuperAdmin")]

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(CertificateUpdateDto certificateDto)
        {
            return CreateActionResult(await _certificateService.UpdateAsync(certificateDto));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,SuperAdmin")]

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var certificate = await _certificateService.GetByIdAsync(id);
            //hata dondur
            await _certificateService.RemoveAsync(certificate);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,SuperAdmin")]

        [HttpPost("[Action]")]
        public async Task<IActionResult> SoftDeleteAsync(string id)
        {
            var certificate = await _certificateService.GetByIdAsync(id);
            //hata dondur
            certificate.IsActive = false;
            await _certificateService.SoftRemove(certificate);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

    }
}
