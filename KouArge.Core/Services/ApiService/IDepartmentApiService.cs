using KouArge.Core.DTOs;

namespace KouArge.Core.Services.ApiService
{
    public interface IDepartmentApiService
    {
        public Task<CustomResponseDto<List<DepartmentWithFacultyDto>>> GetDepartmentWithFacultyAsync();


        public Task<DepartmentDto> Save(DepartmentDto departmentDto);


        public Task<DepartmentDto> GetByIdAsync(IdDto<string> data);


        public Task<bool> UpdateAsync(DepartmentDto departmentDto);


        public Task<bool> DeleteAsync(string id);


    }
}
