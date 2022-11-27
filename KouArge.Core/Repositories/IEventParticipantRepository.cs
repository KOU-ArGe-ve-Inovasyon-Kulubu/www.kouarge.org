using KouArge.Core.Models;

namespace KouArge.Core.Repositories
{
    public interface IEventParticipantRepository : IGenericRepository<EventParticipant>
    {
        public Task<bool> DuplicateData(int eventId, string userId);
    }
}
