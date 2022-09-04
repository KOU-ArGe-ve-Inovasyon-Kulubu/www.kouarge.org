using KouArge.Core.DTOs;
using KouArge.Core.Models;
using System.Text.Json;

namespace www.kouarge.org.ApiServices
{
    public class RoleApiService
    {
        private HttpClient _httpClient;

        public RoleApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AppRole> AddRoleAsync(AppRoleDto role)
        {
            var response = await _httpClient.PostAsJsonAsync("Role", role);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<AppRole>>();
                return responseBody.Data;
            }
            return null;

        }

        public async Task<List<AppRole>> GetRolesAsync()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<AppRole>>>("Role");
                //var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<AppRole>>();
                return response.Data;
            }
            catch (HttpRequestException ex)
            {
                throw;
            }

        }

        public async Task<bool> DeleteRoleAsync(string id)
        {

            var response = await _httpClient.DeleteAsync($"Role/{id}");
            //var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<AppRole>>();
            return response.IsSuccessStatusCode;
        }
    }
}
