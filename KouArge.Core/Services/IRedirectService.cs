using KouArge.Core.DTOs;
using KouArge.Core.DTOs.UpdateDto;
using KouArge.Core.Models;

namespace KouArge.Core.Services
{
    public interface IRedirectService
    {
        public Task<CustomResponseDto<Redirect>> AddAsync(RedirectDto redirectDto);
        public Task<CustomResponseDto<Redirect>> UpdateAsync(RedirectUpdateDto redirectDto);
        public Task<CustomResponseDto<NoContentDto>> DeleteAsync(int id);
        public Task<string> AddCountAsync(string name);
        public Task<CustomResponseDto<List<Redirect>>> GetAllAsync();
        public Task<CustomResponseDto<RedirectDto>> GetByIdAsync(int id);
        public Task<CustomResponseDto<NoContentDto>> SoftDelete(int id);
    }
}
