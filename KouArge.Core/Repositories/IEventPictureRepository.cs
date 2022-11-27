using KouArge.Core.Models;

namespace KouArge.Core.Repositories
{
    public interface IEventPictureRepository : IGenericRepository<EventPicture>
    {
        public IQueryable<EventPicture> GetByEventId(int eventId);
    }
}
