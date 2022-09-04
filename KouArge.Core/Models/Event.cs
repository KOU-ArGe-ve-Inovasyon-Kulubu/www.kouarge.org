namespace KouArge.Core.Models
{
    public class Event:BaseEntity
    {
        public int FormatId { get; set; }
        public int SemesterId { get; set; }
        public int OurFormatId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Speaker { get; set; }
        public DateTime EventDate { get; set; }
        public string Url { get; set; }
        public OurFormat OurFormat { get; set; }

        public Semester Semester { get; set; }

        public ICollection<EventParticipant> EventParticipants { get; set; }

        public ICollection<EventPicture> EventPictures { get; set; }
    }
}
