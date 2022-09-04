using AutoMapper;
using KouArge.API.Filters;
using KouArge.Core.DTOs;
using KouArge.Core.Models;
using KouArge.Core.Services;
using KouArge.Service.Exceptions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace KouArge.API.Controllers
{
    //[TypeFilter(typeof(CustomAuthorizationFilter))]
    [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme )]
    public class DepartmentController : CustomBaseController
    {
        private readonly IService<Department> _service;
        private readonly IMapper _mapper;
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IMapper mapper, IService<Department> service, IDepartmentService departmentService)
        {
            _service = service;
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
            var department = await _service.GetAllAsync();
            var departmensDto = _mapper.Map<List<DepartmentDto>>(department.ToList());
            return CreateActionResult(CustomResponseDto<List<DepartmentDto>>.Success(200, departmensDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var departmen = await _service.GetByIdAsync(id);
            //hata dondur
            var departmenDto = _mapper.Map<DepartmentDto>(departmen);
            return CreateActionResult(CustomResponseDto<DepartmentDto>.Success(200, departmenDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(DepartmentDto departmenDto)
        {
            var department = await _service.AddAsync(_mapper.Map<Department>(departmenDto));
            var departmentDto = _mapper.Map<DepartmentDto>(department);
            return CreateActionResult(CustomResponseDto<DepartmentDto>.Success(201, departmentDto));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(DepartmentUpdateDto departmentDto)
        {
            await _service.UpdateAsync(_mapper.Map<Department>(departmentDto));
            return CreateActionResult(CustomResponseDto<Department>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var department = await _service.GetByIdAsync(id);
            //hata dondur
            await _service.RemoveAsync(department);
            return CreateActionResult(CustomResponseDto<Department>.Success(204));
        }
    }
}
