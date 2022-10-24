using KouArge.Core.DTOs;
using KouArge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Core.Services.ApiService
{
    public interface IRedirectApiService
    {
        public Task Add(int id);
        public Task<CustomResponseDto<List<Redirect>>> GetAllAsync();
        public Task<CustomResponseDto<RedirectDto>> GetByIdAsync(int id);
        public Task<CustomResponseDto<RedirectDto>> AddAsync(RedirectDto redirectDto);
        public Task<bool> UpdateAsync(RedirectDto redirectDto);
        public Task<bool> DeleteAsync(int id);
    }
}
