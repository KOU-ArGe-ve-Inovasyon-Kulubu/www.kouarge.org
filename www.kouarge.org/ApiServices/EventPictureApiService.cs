using KouArge.Core.DTOs;
using KouArge.Core.Services.ApiService;

namespace www.kouarge.org.ApiServices
{
    public class EventPictureApiService : IEventPictureApiService
    {
        private readonly IRequestApiService _request;

        public EventPictureApiService(IRequestApiService request)
        {
            _request = request;
        }

        //Todo: Tekrar bak. bu çalışmıyor. Parametreli hale getir. tek bir fonksiyon
        public async Task<EventPictureDto> Save(EventPictureDto eventPictureDto)
        {
            var response = await _request.PostAsync<CustomResponseDto<EventPictureDto>, EventPictureDto>("EventPicture", eventPictureDto);
            return response.Data;
        }

        public async Task<IEnumerable<EventPictureDto>> Save(IEnumerable<EventPictureDto> eventPictureDto)
        {
            var response = await _request.PostAsync<CustomResponseDto<IEnumerable<EventPictureDto>>, IEnumerable<EventPictureDto>>("EventPicture/SaveRange", eventPictureDto);

            return response.Data;
        }
    }
}
