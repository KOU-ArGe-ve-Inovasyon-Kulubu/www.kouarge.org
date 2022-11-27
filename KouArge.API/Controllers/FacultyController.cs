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
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "SuperAdmin")]

    //[Authorize(Roles = "admin, user")]
    public class FacultyController : CustomBaseController
    {
        private readonly IFacultyService _facultyService;
        private readonly IMapper _mapper;
        public FacultyController(IFacultyService facultyService, IMapper mapper)
        {
            _facultyService = facultyService;
            _mapper = mapper;
        }


        [HttpGet("[Action]")]
        public async Task<IActionResult> GetAllFacultysWithDepartments()
        {
            return CreateActionResult(await _facultyService.GetAllFacultysWithDepartmentsAsync());
        }


        [HttpGet("[Action]/{facultyId}")]
        public async Task<IActionResult> GetSingleFacultyByIdWithDepartment(int facultyId)
        {
            return CreateActionResult(await _facultyService.GetSingleFacultyByIdWithDepartmentAsync(facultyId));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var faculty = await _facultyService.GetAllAsync();
            var facultyDto = _mapper.Map<List<FacultyDto>>(faculty.OrderBy(x => x.Name).ToList());
            return CreateActionResult(CustomResponseDto<List<FacultyDto>>.Success(200, facultyDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var faculty = await _facultyService.GetByIdAsync(id);
            var facultyDto = _mapper.Map<FacultyDto>(faculty);
            return CreateActionResult(CustomResponseDto<FacultyDto>.Success(200, facultyDto));
        }


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,SuperAdmin")]

        [HttpPost]
        public async Task<IActionResult> Save(FacultyDto newFacultyDto)
        {
            var faculty = await _facultyService.AddAsync(_mapper.Map<Faculty>(newFacultyDto));
            var facultyDto = _mapper.Map<FacultyDto>(faculty);
            return CreateActionResult(CustomResponseDto<FacultyDto>.Success(201, facultyDto));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,SuperAdmin")]

        [HttpPut]
        public async Task<IActionResult> Update(FacultyUpdateDto newFacultyDto)
        {
            await _facultyService.UpdateAsync(_mapper.Map<Faculty>(newFacultyDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,SuperAdmin")]

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var faculty = await _facultyService.GetByIdAsync(id);
            await _facultyService.RemoveAsync(faculty);//**********
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,SuperAdmin")]

        [HttpPost("[Action]")]
        public async Task<IActionResult> SoftDeleteAsync(int id)
        {
            var faculty = await _facultyService.GetByIdAsync(id);
            //hata dondur
            faculty.IsActive = false;
            await _facultyService.SoftRemove(faculty);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

    }
}
