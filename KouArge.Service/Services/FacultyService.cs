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
    public class FacultyService : Service<Faculty>, IFacultyService
    {
        private readonly IFacultyRepository _facultyRepository;
        private readonly IMapper _mapper;
        public FacultyService(IUnitOfWork unitOfWork, IGenericRepository<Faculty> repository, IFacultyRepository facultyRepository, IMapper mapper) : base(unitOfWork, repository)
        {
            _facultyRepository = facultyRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<List<FacultyWithDepartmentsDto>>> GetAllFacultysWithDepartmentsAsync()
        {
            var faculty = await _facultyRepository.GetAllFacultysWithDepartmentsAsync().ToListAsync();
            var facultiesDto = _mapper.Map<List<FacultyWithDepartmentsDto>>(faculty);
            return CustomResponseDto<List<FacultyWithDepartmentsDto>>.Success(200, facultiesDto);
        }

        public async Task<CustomResponseDto<FacultyWithDepartmentsDto>> GetSingleFacultyByIdWithDepartmentAsync(int id)
        {
            var faculty = await _facultyRepository.GetSingleFacultyByIdWithDepartmentAsync(id);

            if (faculty == null)
                throw new NotFoundException($"{typeof(Faculty).Name}({id}) not found.");

            var facultysDto = _mapper.Map<FacultyWithDepartmentsDto>(faculty);
            return CustomResponseDto<FacultyWithDepartmentsDto>.Success(200, facultysDto);
        }
    }
}
