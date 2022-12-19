namespace KouArge.Core.DTOs
{
    public class SpeakerDto:BaseDto
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string? ImgUrl { get; set; }
    }
}
