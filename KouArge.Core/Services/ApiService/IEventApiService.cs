using KouArge.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Core.Services.ApiService
{
    public interface IEventApiService
    {
        Task<CustomResponseDto<IEnumerable<EventDto>>> GetAllAsync();
        Task<CustomResponseDto<IEnumerable<EventWithFormatDto>>> GetAllWithFormatAsync();
        Task<CustomResponseDto<IEnumerable<EventWithPictureDto>>> GetAllWithDetailsAsync();
        Task<CustomResponseDto<EventDto>> GetByIdAsync(int id);
        Task<CustomResponseDto<EventDto>> AddAsync(EventDto eventDto);
        Task<CustomResponseDto<NoContentDto>> UpdateAsync(EventDto eventDto);
        Task<CustomResponseDto<NoContentDto>> DeleteAsync(int id);



    }
}
