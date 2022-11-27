using KouArge.Core.DTOs;
using KouArge.Core.Services.ApiService;

namespace www.kouarge.org.ApiServices
{
    public class DepartmentApiService : IDepartmentApiService
    {
        private readonly IRequestApiService _request;

        public DepartmentApiService(IRequestApiService request)
        {
            _request = request;
        }

        public async Task<CustomResponseDto<List<DepartmentWithFacultyDto>>> GetDepartmentWithFacultyAsync()
        {
            var response = await _request.GetAsync<CustomResponseDto<List<DepartmentWithFacultyDto>>>("department/departmentWithFaculty");
            return response;
        }

        public async Task<DepartmentDto> Save(DepartmentDto departmentDto)
        {
            var response = await _request.PostAsync<CustomResponseDto<DepartmentWithFacultyDto>, DepartmentDto>
                                 ("department", departmentDto);
            return response.Data;
        }

        public async Task<DepartmentDto> GetByIdAsync(IdDto<string> data)
        {
            var response = await _request.PostAsync<CustomResponseDto<DepartmentDto>, IdDto<string>>("department", data);
            return response.Data;
        }

        public async Task<bool> UpdateAsync(DepartmentDto departmentDto)
        {
            var response = await _request.PutAsync("department", departmentDto);
            return response;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var response = await _request.DeleteAsync($"department/{id}");
            return response;
        }

    }
}
