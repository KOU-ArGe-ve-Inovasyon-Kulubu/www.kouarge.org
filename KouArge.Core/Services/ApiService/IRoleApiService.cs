using KouArge.Core.DTOs;
using KouArge.Core.Models;

namespace KouArge.Core.Services.ApiService
{
    public interface IRoleApiService
    {
        public Task<CustomResponseDto<AppRole>> AddRoleAsync(AppRoleDto role);
        public Task<CustomResponseDto<IEnumerable<AppRole>>> GetRolesAsync();
        public Task<CustomResponseDto<NoContentDto>> DeleteRoleAsync(string id);

        public Task<CustomResponseDto<IEnumerable<AppUserDto>>> GetUsersByRoleNameAsync(string roleName);

        public Task<CustomResponseDto<NoContentDto>> AssignRoleAsync(AppRoleUserDto role);

        public Task<CustomResponseDto<NoContentDto>> RemoveRoleUserAsync(AppRoleUserDto role);
    }
}
