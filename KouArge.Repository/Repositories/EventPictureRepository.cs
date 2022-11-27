using KouArge.Core.Models;
using KouArge.Core.Repositories;

namespace KouArge.Repository.Repositories
{
    public class EventPictureRepository : GenericRepository<EventPicture>, IEventPictureRepository
    {
        public EventPictureRepository(AppIdentityDbContext context) : base(context)
        {
        }

        public IQueryable<EventPicture> GetByEventId(int eventId)
        {
            return _context.EventPictures.Where(x => x.EventId == eventId).AsQueryable();
        }

    }
}
