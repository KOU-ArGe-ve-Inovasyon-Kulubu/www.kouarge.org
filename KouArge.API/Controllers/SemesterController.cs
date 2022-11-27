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
    public class SemesterController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly ISemesterService _semesterService;
        public SemesterController(IMapper mapper, ISemesterService semesterService)
        {
            _mapper = mapper;
            _semesterService = semesterService;
        }


        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var semesters = await _semesterService.GetAllAsync();
            var semestersDto = _mapper.Map<List<SemesterDto>>(semesters.ToList());
            return CreateActionResult(CustomResponseDto<List<SemesterDto>>.Success(200, semestersDto));
        }

        [AllowAnonymous]

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var semester = await _semesterService.GetByIdAsync(id);
            //hata dondur
            var semesterDto = _mapper.Map<SemesterDto>(semester);
            return CreateActionResult(CustomResponseDto<SemesterDto>.Success(200, semesterDto));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Manager,Admin,SuperAdmin")]

        [HttpPost]
        public async Task<IActionResult> Save(SemesterDto semesterDto)
        {
            var semester = await _semesterService.AddAsync(_mapper.Map<Semester>(semesterDto));
            var semesterDtos = _mapper.Map<SemesterDto>(semester);
            return CreateActionResult(CustomResponseDto<SemesterDto>.Success(201, semesterDtos));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Manager,Admin,SuperAdmin")]

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(SemesterUpdateDto semesterDto)
        {
            await _semesterService.UpdateAsync(_mapper.Map<Semester>(semesterDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Manager,Admin,SuperAdmin")]

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var semester = await _semesterService.GetByIdAsync(id);
            //hata dondur
            await _semesterService.RemoveAsync(semester);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Manager,Admin,SuperAdmin")]

        [HttpPost("[Action]")]
        public async Task<IActionResult> SoftDeleteAsync(int id)
        {
            var semester = await _semesterService.GetByIdAsync(id);
            //hata dondur
            semester.IsActive = false;
            await _semesterService.SoftRemove(semester);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
