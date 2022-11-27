using KouArge.Core.Models;
using KouArge.Core.Repositories;
using KouArge.Core.Services;
using KouArge.Core.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace KouArge.Service.Services
{
    public class EventPictureService : Service<EventPicture>, IEventPictureService
    {
        private readonly IEventPictureRepository _eventPictureRepository;
        public EventPictureService(IUnitOfWork unitOfWork, IGenericRepository<EventPicture> repository, IEventPictureRepository eventPictureRepository) : base(unitOfWork, repository)
        {
            _eventPictureRepository = eventPictureRepository;
        }

        public async Task<IEnumerable<EventPicture>> GetByEventId(int eventId)
        {
            return await _eventPictureRepository.GetByEventId(eventId).ToListAsync();
        }
    }
}
