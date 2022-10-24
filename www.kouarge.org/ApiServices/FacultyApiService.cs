using KouArge.Core.DTOs;
using KouArge.Core.Services.ApiService;
using KouArge.Service.Exceptions;
using System.Net;

namespace www.kouarge.org.ApiServices
{
    public class FacultyApiService: IFacultyApiService
    {
        private readonly IRequestApiService _request;

        public FacultyApiService(IRequestApiService requestApiService)
        {
            _request = requestApiService;
        }



        public async Task<List<FacultyWithDepartmentsDto>> GetDepartmentWithFacultyAsync()
        {
            var response = await _request.GetAsync<CustomResponseDto<List<FacultyWithDepartmentsDto>>>("faculty/GetAllFacultysWithDepartments");
            return response.Data;
        }

        public async Task<FacultyWithDepartmentsDto> GetDepartmentByFacultyIdAsync(int id)
        {
            var response = await _request.GetAsync<CustomResponseDto<FacultyWithDepartmentsDto>>($"faculty/GetSingleFacultyByIdWithDepartment/{id}");
            return response.Data;
        }

        public async Task<List<FacultyDto>> GetAllAsync()
        {
            var response = await _request.GetAsync<CustomResponseDto<List<FacultyDto>>>("faculty");
            return response.Data;
        }

        public async Task<FacultyDto> Save(FacultyDto facultyDto)
        {
            var response = await _request.PostAsync<CustomResponseDto<FacultyDto>, FacultyDto>("faculty", facultyDto);
            return response.Data;
        }

        public async Task<FacultyDto> GetByIdAsync(int id)
        {
            //var response = await _request.PostAsync<CustomResponseDto<FacultyDto>> ($"faculty/{id}");
            var response = await _request.GetAsync<CustomResponseDto<FacultyDto>>($"faculty/{id}");

            return response.Data;
        }

        public async Task<bool> UpdateAsync(FacultyDto facultyDto)
        {
            var response = await _request.PutAsync("faculty", facultyDto);
            return response;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _request.DeleteAsync($"faculty/{id}");
            return response;
        }
    }
}
