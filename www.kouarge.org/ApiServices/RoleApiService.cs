using KouArge.Core.DTOs;
using KouArge.Core.Models;
using System.Text.Json;

namespace www.kouarge.org.ApiServices
{
    public class RoleApiService
    {
        private readonly RequestApiService _request;

        public RoleApiService(RequestApiService request)
        {
            _request = request;
        }

        public async Task<AppRole> AddRoleAsync(AppRoleDto role)
        {
            var response = await _request.PostAsync<AppRole, AppRoleDto>("Role", role);
            return response;
        }

        public async Task<List<AppRole>> GetRolesAsync()
        {
            var response = await _request.GetAsync<CustomResponseDto<List<AppRole>>>("Role");
            return response.Data;
        }

        public async Task<bool> DeleteRoleAsync(string id)
        {
            var response = await _request.DeleteAsync($"Role/{id}");
            return response;
        }
    }
}
