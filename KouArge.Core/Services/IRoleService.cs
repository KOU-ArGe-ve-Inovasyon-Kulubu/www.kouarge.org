using KouArge.Core.DTOs;
using KouArge.Core.Models;

namespace KouArge.Core.Services
{
    public interface IRoleService
    {
        //Task<CustomResponseDto<AppRole>> AddRoleAsync(AppRoleDto role);
        Task<CustomResponseDto<NoContentDto>> RemoveAsync(string id);
        //Task<CustomResponseDto<NoContentDto>> UpdateAsync(string id);
        Task<CustomResponseDto<IEnumerable<AppRole>>> GetAllRolesAsync();
        Task<CustomResponseDto<IEnumerable<AppUserDto>>> GetUserByRoleId(string id);

        Task<CustomResponseDto<AppRole>> AddRoleAsync(AppRoleDto role);
        Task<CustomResponseDto<IEnumerable<AppUserDto>>> GetUsersByRoleNameAsync(string roleName);
        Task<CustomResponseDto<IEnumerable<StringRoleDto>>> GetRoleByUser(string token);

        Task<CustomResponseDto<NoContentDto>> AssignRoleAsync(AppRoleUserDto data);
        Task<CustomResponseDto<NoContentDto>> RemoveRoleUserAsync(AppRoleUserDto data);

    }
}
