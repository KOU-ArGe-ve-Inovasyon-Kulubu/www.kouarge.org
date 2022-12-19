using KouArge.Core.Models;

namespace KouArge.Core.Repositories
{
    public interface IEventParticipantRepository : IGenericRepository<EventParticipant>
    {
        Task<bool> DuplicateData(int eventId, string userId);
        Task<EventParticipant> GetByEventId(int eventId);
        Task<IEnumerable<EventParticipant>> GetAllByEventIdAsync(int eventId);
    }
}
