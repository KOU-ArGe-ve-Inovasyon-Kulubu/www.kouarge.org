using AutoMapper;
using KouArge.Core.DTOs;
using KouArge.Core.Models;
using KouArge.Core.Repositories;
using KouArge.Core.Services;
using KouArge.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Service.Services
{
    public class DepartmentService : Service<Department>, IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;
        public DepartmentService(IUnitOfWork unitOfWork, IGenericRepository<Department> repository, IDepartmentRepository departmentRepository, IMapper mapper) : base(unitOfWork, repository)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<IEnumerable<DepartmentWithFacultyDto>>> GetDepartmentWithFacultyAsync()
        {
            var department = await _departmentRepository.GetDepartmentWithFaculty();
            var departmentDto = _mapper.Map<IEnumerable<DepartmentWithFacultyDto>>(department.ToList());
            return CustomResponseDto<IEnumerable<DepartmentWithFacultyDto>>.Success(200, departmentDto);
        }
    }
}
