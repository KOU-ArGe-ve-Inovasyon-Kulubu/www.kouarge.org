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
    //[TypeFilter(typeof(CustomAuthorizationFilter))]
    //[Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme )]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class DepartmentController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IMapper mapper, IDepartmentService departmentService)
        {
            _mapper = mapper;
            _departmentService = departmentService;
        }

        //api/controller_ismi/action    api/Department/DepartmentWithFaculty
        [HttpGet("[Action]")]
        public async Task<IActionResult> DepartmentWithFaculty()
        {
            return CreateActionResult(await _departmentService.GetDepartmentWithFacultyAsync());

        }


        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var department = await _departmentService.GetAllAsync();
            var departmensDto = _mapper.Map<List<DepartmentDto>>(department.ToList());
            return CreateActionResult(CustomResponseDto<List<DepartmentDto>>.Success(200, departmensDto));
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            var departmen = await _departmentService.GetByIdAsync(id);
            //hata dondur
            var departmenDto = _mapper.Map<DepartmentDto>(departmen);
            return CreateActionResult(CustomResponseDto<DepartmentDto>.Success(200, departmenDto));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,SuperAdmin")]

        [HttpPost]
        public async Task<IActionResult> Save(DepartmentDto departmenDto)
        {
            var department = await _departmentService.AddAsync(_mapper.Map<Department>(departmenDto));
            var departmentDto = _mapper.Map<DepartmentDto>(department);
            return CreateActionResult(CustomResponseDto<DepartmentDto>.Success(201, departmentDto));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,SuperAdmin")]

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(DepartmentUpdateDto departmentDto)
        {
            await _departmentService.UpdateAsync(_mapper.Map<Department>(departmentDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,SuperAdmin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var department = await _departmentService.GetByIdAsync(id);
            //hata dondur
            await _departmentService.RemoveAsync(department);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,SuperAdmin")]
        [HttpPost("[Action]")]
        public async Task<IActionResult> SoftDeleteAsync(string id)
        {
            var department = await _departmentService.GetByIdAsync(id);
            //hata dondur
            department.IsActive = false;
            await _departmentService.SoftRemove(department);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
