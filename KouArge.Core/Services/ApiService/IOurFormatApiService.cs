using KouArge.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Core.Services.ApiService
{
    public interface IOurFormatApiService
    {
        Task<CustomResponseDto<IEnumerable<OurFormatDto>>> GetAllAsync();
        Task<CustomResponseDto<OurFormatDto>> GetByIdAsync(int id);
        Task<CustomResponseDto<OurFormatDto>> AddAsync(OurFormatDto formatDto);
        Task<CustomResponseDto<NoContentDto>> UpdateAsync(OurFormatDto formatDto);
        Task<CustomResponseDto<NoContentDto>> DeleteAsync(int id);
    }
}
