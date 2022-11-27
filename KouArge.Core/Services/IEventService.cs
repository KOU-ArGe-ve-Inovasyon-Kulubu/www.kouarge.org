using KouArge.Core.DTOs;
using KouArge.Core.Models;

namespace KouArge.Core.Services
{
    public interface IEventService : IService<Event>
    {
        Task<CustomResponseDto<IEnumerable<EventWithPictureDto>>> GetAllWithDetails();
        Task<CustomResponseDto<EventWithPictureDto>> GetByIdWithDetailsAsync(int id);


    }
}
