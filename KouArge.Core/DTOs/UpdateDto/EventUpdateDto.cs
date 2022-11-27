namespace KouArge.Core.DTOs.UpdateDto
{
    public class EventUpdateDto : UpdateDto
    {
        public int SemesterId { get; set; }
        public int OurFormatId { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public DateTime EventDate { get; set; }
        public string ImgBackUrl { get; set; }
        public int ReadCount { get; set; }
    }
}
