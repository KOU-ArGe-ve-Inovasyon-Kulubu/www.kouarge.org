using KouArge.Core.DTOs;
using KouArge.Service.Exceptions;
using System.Net;

namespace www.kouarge.org.ApiServices
{
    public class FacultyApiService
    {
        private readonly HttpClient _httpClient;

        public FacultyApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<FacultyDto>> GetAllAsync()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<FacultyDto>>>("faculty");
                return response.Data;
            }
            catch (HttpRequestException ex)
            {

                if (ex.StatusCode == HttpStatusCode.Unauthorized)
                    throw new UnAuthorizedException(ex.Message);

                if (ex.StatusCode == HttpStatusCode.Forbidden)
                    throw new ForbiddenException("yetki yok");

                return null;

            }
  
        }

        public async Task<FacultyDto> Save(FacultyDto facultyDto)
        {
            var response = await _httpClient.PostAsJsonAsync("faculty", facultyDto);
            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<FacultyDto>>();
            return responseBody.Data;
        }

        public async Task<FacultyDto> GetByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<FacultyDto>>($"faculty/{id}");
                return response.Data;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> UpdateAsync(FacultyDto facultyDto)
        {
            var response = await _httpClient.PutAsJsonAsync("faculty", facultyDto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"faculty/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
