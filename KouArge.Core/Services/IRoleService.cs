using KouArge.Core.DTOs;
using KouArge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Core.Services
{
    public interface IRoleService
    {
        Task<CustomResponseDto<AppRole>> AddRoleAsync(AppRoleDto role);
        Task<CustomResponseDto<NoContentDto>> RemoveAsync(string id);
        Task<CustomResponseDto<IEnumerable<AppRole>>> GetAllRolesAsync();
        Task<CustomResponseDto<IEnumerable<AppUserDto>>> GetUserByRoleId(string id);

    }
}
