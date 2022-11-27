using KouArge.Core.Models;

namespace KouArge.Core.Services
{
    public interface IEventPictureService : IService<EventPicture>
    {
        public Task<IEnumerable<EventPicture>> GetByEventId(int eventId);
    }
}
