namespace KouArge.Core.DTOs
{
    public class EventWithSpeakersDto : BaseDto
    {
        public int SemesterId { get; set; }
        public int OurFormatId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; }

        public DateTime EventDate { get; set; }
        public string ImgBackUrl { get; set; }
        public int ReadCount { get; set; }
        public ICollection<SpeakerDto> Speakers { get; set; }

    }
}
