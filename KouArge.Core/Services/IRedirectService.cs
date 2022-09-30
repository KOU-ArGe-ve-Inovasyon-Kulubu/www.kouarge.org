using KouArge.Core.DTOs;
using KouArge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Core.Services
{
    public interface IRedirectService
    {
        public Task<CustomResponseDto<Redirect>> AddAsync(RedirectDto redirectDto);
        public Task<CustomResponseDto<Redirect>> UpdateAsync(RedirectDto redirectDto);
        public Task<CustomResponseDto<NoContentDto>> DeleteAsync(int id);
        public Task<string> AddCountAsync(string name);
        public Task<CustomResponseDto<List<Redirect>>> GetAllAsync();
        public Task<CustomResponseDto<RedirectDto>> GetByIdAsync(int id);
    }
}
