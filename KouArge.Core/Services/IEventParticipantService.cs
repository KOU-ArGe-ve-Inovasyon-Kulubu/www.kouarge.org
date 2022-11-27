using KouArge.Core.DTOs;
using KouArge.Core.Models;

namespace KouArge.Core.Services
{
    public interface IEventParticipantService : IService<EventParticipant>
    {
        public Task DuplicateData(int eventId, string userId);
        public Task<CustomResponseDto<EventParticipantDto>> AddAsync(string token, EventParticipant eventParticipant);
        public Task<CustomResponseDto<NoContentDto>> RemoveAsync(DeleteDto deleteDto);
    }
}
