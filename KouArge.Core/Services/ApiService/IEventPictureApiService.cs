using KouArge.Core.DTOs;

namespace KouArge.Core.Services.ApiService
{
    public interface IEventPictureApiService
    {
        Task<CustomResponseDto<IEnumerable<EventPictureDto>>> Save(IEnumerable<EventPictureDto> eventPictureDto);
        Task<CustomResponseDto<EventPictureDto>> Save(EventPictureDto eventPictureDto);
        Task<CustomResponseDto<IEnumerable<EventPictureDto>>> GetAllByEventIdAsync(int eventId);
        Task<CustomResponseDto<EventPictureDto>> GetByIdAsync(int id);
        Task<CustomResponseDto<NoContentDto>> UpdateAsync(EventPictureDto eventPictureDto);
        Task<CustomResponseDto<NoContentDto>> DeleteAsync(int id);

    }
}
