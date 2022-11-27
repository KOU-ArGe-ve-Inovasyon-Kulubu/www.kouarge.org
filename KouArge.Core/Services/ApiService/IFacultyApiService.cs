using KouArge.Core.DTOs;

namespace KouArge.Core.Services.ApiService
{
    public interface IFacultyApiService
    {
        public Task<List<FacultyWithDepartmentsDto>> GetDepartmentWithFacultyAsync();
        public Task<FacultyWithDepartmentsDto> GetDepartmentByFacultyIdAsync(int id);
        public Task<List<FacultyDto>> GetAllAsync();
        public Task<FacultyDto> Save(FacultyDto facultyDto);
        public Task<FacultyDto> GetByIdAsync(int id);
        public Task<bool> UpdateAsync(FacultyDto facultyDto);
        public Task<bool> DeleteAsync(int id);
    }
}
