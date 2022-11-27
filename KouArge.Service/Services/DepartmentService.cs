using AutoMapper;
using KouArge.Core.DTOs;
using KouArge.Core.Models;
using KouArge.Core.Repositories;
using KouArge.Core.Services;
using KouArge.Core.UnitOfWorks;
using KouArge.Service.Exceptions;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Department> GetByIdAsync(string id)
        {
            var entity = await _departmentRepository.GetByIdAsync(id);
            if (entity == null)
                throw new NotFoundException($"{typeof(Department).Name}({id}) not found.");

            return entity;
        }

        public async Task<CustomResponseDto<IEnumerable<DepartmentWithFacultyDto>>> GetDepartmentWithFacultyAsync()
        {
            var department = await _departmentRepository.GetDepartmentWithFaculty().ToListAsync();
            var departmentDto = _mapper.Map<IEnumerable<DepartmentWithFacultyDto>>(department);
            return CustomResponseDto<IEnumerable<DepartmentWithFacultyDto>>.Success(200, departmentDto);
        }

    }
}
