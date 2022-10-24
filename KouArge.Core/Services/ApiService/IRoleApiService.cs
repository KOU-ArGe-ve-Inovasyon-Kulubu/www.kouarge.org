using KouArge.Core.DTOs;
using KouArge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Core.Services.ApiService
{
    public interface IRoleApiService
    {
        public Task<AppRole> AddRoleAsync(AppRoleDto role);
        public Task<List<AppRole>> GetRolesAsync();
        public Task<bool> DeleteRoleAsync(string id);
    }
}
