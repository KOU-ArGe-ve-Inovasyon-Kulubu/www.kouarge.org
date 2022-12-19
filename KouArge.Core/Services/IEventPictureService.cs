using KouArge.Core.DTOs;
using KouArge.Core.Models;

namespace KouArge.Core.Services
{
    public interface IEventPictureService : IService<EventPicture>
    {
        Task<CustomResponseDto<IEnumerable<EventPictureDto>>> GetAllByEventId(int eventId);
    }
}
