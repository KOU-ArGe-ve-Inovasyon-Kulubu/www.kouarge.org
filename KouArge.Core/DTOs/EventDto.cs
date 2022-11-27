namespace KouArge.Core.DTOs
{
    public class EventDto : BaseDto
    {
        public int SemesterId { get; set; }
        public int OurFormatId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        public string ImgBackUrl { get; set; }
        public int ReadCount { get; set; } = 0;
    }
}
