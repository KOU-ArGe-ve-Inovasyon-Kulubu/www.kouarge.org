using KouArge.Core.DTOs;
using KouArge.Core.Models;

namespace KouArge.Core.Services.ApiService
{
    public interface IRoleApiService
    {
        public Task<AppRole> AddRoleAsync(AppRoleDto role);
        public Task<List<AppRole>> GetRolesAsync();
        public Task<bool> DeleteRoleAsync(string id);
    }
}
