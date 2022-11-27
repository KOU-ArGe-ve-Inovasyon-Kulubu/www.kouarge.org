using KouArge.Core.DTOs;
using KouArge.Core.Models;

namespace KouArge.Core.Services.ApiService
{
    public interface IRedirectApiService
    {
        public Task<CustomResponseDto<List<Redirect>>> GetAllAsync();
        public Task<CustomResponseDto<RedirectDto>> GetByIdAsync(int id);
        public Task<CustomResponseDto<string>> AddCountAsync(string Name);
        public Task<CustomResponseDto<RedirectDto>> AddAsync(RedirectDto redirectDto);
        public Task<bool> UpdateAsync(RedirectDto redirectDto);
        public Task<bool> DeleteAsync(int id);
    }
}
