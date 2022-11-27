using KouArge.Core.DTOs;
using KouArge.Core.Models;

namespace KouArge.Core.Services
{
    public interface IFacultyService : IService<Faculty>
    {
        public Task<CustomResponseDto<List<FacultyWithDepartmentsDto>>> GetAllFacultysWithDepartmentsAsync();
        public Task<CustomResponseDto<FacultyWithDepartmentsDto>> GetSingleFacultyByIdWithDepartmentAsync(int id);
    }
}
