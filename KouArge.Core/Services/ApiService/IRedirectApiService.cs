using KouArge.Core.DTOs;
using KouArge.Core.Models;

namespace KouArge.Core.Services.ApiService
{
    public interface IRedirectApiService
    {
        public Task<CustomResponseDto<IEnumerable<Redirect>>> GetAllAsync();
        public Task<CustomResponseDto<RedirectDto>> GetByIdAsync(int id);
        public Task<CustomResponseDto<string>> AddCountAsync(string Name);
        public Task<CustomResponseDto<RedirectDto>> AddAsync(RedirectDto redirectDto);

        public Task<CustomResponseDto<NoContentDto>> UpdateAsync(RedirectDto redirectDto);

        public Task<CustomResponseDto<NoContentDto>> DeleteAsync(int id);
    }
}
