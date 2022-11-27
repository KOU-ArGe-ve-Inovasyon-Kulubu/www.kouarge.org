namespace KouArge.Core.DTOs
{
    public class EventWithPictureDto : EventWithSpeakersDto
    {
        public IEnumerable<EventPictureDto> EventPictures { get; set; }
    }
}
