using KouArge.Core.DTOs;
using KouArge.Core.Models;

namespace KouArge.Core.Services
{
    public interface IEventParticipantService : IService<EventParticipant>
    {
        Task DuplicateData(int eventId, string userId);
        Task<CustomResponseDto<EventParticipantDto>> AddAsync(string token, EventParticipant eventParticipant);
        Task<CustomResponseDto<NoContentDto>> RemoveAsync(DeleteDto deleteDto);
        Task<CustomResponseDto<NoContentDto>> RemoveByUserIdAsync(DeleteByUserIdDto deleteDto);
        Task<EventParticipant> GetByEventId(int eventId);
        Task<CustomResponseDto<IEnumerable<EventParticipantDto>>> GetAllByEventIdAsync(int eventId);
        Task<CustomResponseDto<NoContentDto>> RemoveByIdAsync(int id);
    }
}
