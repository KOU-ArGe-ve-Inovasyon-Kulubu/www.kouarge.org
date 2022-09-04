using KouArge.Core.DTOs;
using KouArge.Service.Exceptions;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using System.Net.Http.Headers;

namespace www.kouarge.org.ApiServices
{
    public class DepartmentApiService
    {
        private HttpClient _httpClient;

        public DepartmentApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CustomResponseDto<List<DepartmentWithFacultyDto>>> GetDepartmentWithFacultyAsync()
        {
            try
            {
              
                var request=  _httpClient.GetAsync("department/departmentWithFaculty");
                var response = await request.Result.Content.ReadFromJsonAsync<CustomResponseDto<List<DepartmentWithFacultyDto>>>();
                //var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<DepartmentWithFacultyDto>>>("department/departmentWithFaculty");
                return response;
            }
            catch (HttpRequestException ex)
            {
                if(ex.StatusCode == HttpStatusCode.Unauthorized)
                //return new List<DepartmentWithFacultyDto>() { new DepartmentWithFacultyDto()
                //{ Errors=new List<string>() { ex.Message }, ErrorStatus=401 } };
                throw new UnAuthorizedException(ex.Message);

                if(ex.StatusCode == HttpStatusCode.Forbidden)
                    throw new ForbiddenException("yetki yok");

                return null;

            }
        }

        public async Task<DepartmentDto> Save(DepartmentDto departmentDto)
        {
            var response = await _httpClient.PostAsJsonAsync("department", departmentDto);
            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<DepartmentDto>>();
            return responseBody.Data;
        }

        public async Task<DepartmentDto> GetByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<DepartmentDto>>($"department/{id}");
                return response.Data;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public async Task<bool> UpdateAsync(DepartmentDto departmentDto)
        {
            var response = await _httpClient.PutAsJsonAsync("department", departmentDto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"department/{id}");
            return response.IsSuccessStatusCode;
        }

    }
}
