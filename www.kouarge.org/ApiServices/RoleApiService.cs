using KouArge.Core.DTOs;
using KouArge.Core.Models;
using KouArge.Core.Services.ApiService;
using System.Text.Json;

namespace www.kouarge.org.ApiServices
{
    public class RoleApiService: IRoleApiService
    {
        private readonly IRequestApiService _request;

        public RoleApiService(IRequestApiService request)
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
