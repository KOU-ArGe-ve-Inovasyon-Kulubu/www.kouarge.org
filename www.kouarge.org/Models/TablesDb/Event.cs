namespace www.kouarge.org.Models.TablesDb
{
    public class Event
    {
        public int Id { get; set; }
        public int FormatId { get; set; }
        public int SemesterId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Speaker { get; set; }

        public DateTime EventDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Url { get; set; }
    }
}
