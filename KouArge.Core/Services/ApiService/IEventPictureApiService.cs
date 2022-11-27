using KouArge.Core.DTOs;

namespace KouArge.Core.Services.ApiService
{
    public interface IEventPictureApiService
    {
        //public Task<IEnumerable<EventPictureDto>> Save(List<EventPictureDto> eventPictureDto);
        Task<IEnumerable<EventPictureDto>> Save(IEnumerable<EventPictureDto> eventPictureDto);
        public Task<EventPictureDto> Save(EventPictureDto eventPictureDto);

    }
}
