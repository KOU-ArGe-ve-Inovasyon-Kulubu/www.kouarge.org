using KouArge.Core.Models;
using KouArge.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KouArge.Repository.Repositories
{
    public class EventParticipantRepository : GenericRepository<EventParticipant>, IEventParticipantRepository
    {
        public EventParticipantRepository(AppIdentityDbContext context) : base(context)
        {
        }

        public async Task<bool> DuplicateData(int eventId, string userId)
        {
            return await _context.EventParticipants.AnyAsync(x => x.EventId == eventId && x.AppUserId == userId);

            //return await _context.EventParticipants.SingleOrDefaultAsync(x => x.EventId == eventId && x.AppUserId == userId);
        }

    }
}
