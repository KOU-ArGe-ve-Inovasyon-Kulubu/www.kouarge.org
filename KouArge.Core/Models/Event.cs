namespace KouArge.Core.Models
{
    public class Event : BaseEntity
    {
        //public int FormatId { get; set; }//???
        public int SemesterId { get; set; }
        public int OurFormatId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        //public string Speaker { get; set; }//TODO: Tablo ekle sosyal medya fotograf ?
        public DateTime EventDate { get; set; }
        public string ImgBackUrl { get; set; }
        public int ReadCount { get; set; }
        public OurFormat OurFormat { get; set; }
        public Semester Semester { get; set; }
        public ICollection<Certificate> Certificates { get; set; }
        public ICollection<Speaker> Speakers { get; set; }
        public ICollection<EventParticipant> EventParticipants { get; set; }
        public ICollection<EventPicture> EventPictures { get; set; }
    }
}
