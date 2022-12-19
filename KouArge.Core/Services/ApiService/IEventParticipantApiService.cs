using KouArge.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Core.Services.ApiService
{
    public interface IEventParticipantApiService
    {
        Task<CustomResponseDto<IEnumerable<EventParticipantWithUserDto>>> GetAllUserByEventIdAsync(int eventId);
        Task<CustomResponseDto<IEnumerable<EventParticipantDto>>> GetAllByEventIdAsync(int eventId);
        Task<CustomResponseDto<IEnumerable<EventParticipantDto>>> GetAllAsync();
        Task<CustomResponseDto<EventParticipantDto>> GetByIdAsync(int id);
        Task<CustomResponseDto<EventParticipantDto>> AddAsync(EventParticipantDto eventParticipantDto);
        Task<CustomResponseDto<NoContentDto>> UpdateAsync(EventParticipantDto eventParticipantDto);
        Task<CustomResponseDto<NoContentDto>> DeleteAsync(int id);
     
    }
}
