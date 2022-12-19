using KouArge.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Core.Services.ApiService
{
    public interface ISpeakerApiService
    {
        Task<CustomResponseDto<IEnumerable<SpeakerDto>>> GetAllByEventIdAsync(int eventId);
        Task<CustomResponseDto<IEnumerable<SpeakerDto>>> GetAllAsync();
        Task<CustomResponseDto<SpeakerDto>> GetByIdAsync(int id);
        Task<CustomResponseDto<SpeakerDto>> AddAsync(SpeakerDto speakerDto);
        Task<CustomResponseDto<IEnumerable<SpeakerDto>>> AddRangeAsync(IEnumerable<SpeakerDto> speakersDto);
        Task<CustomResponseDto<NoContentDto>> UpdateAsync(SpeakerDto speakerDto);
        Task<CustomResponseDto<NoContentDto>> DeleteAsync(int id);

    }
}