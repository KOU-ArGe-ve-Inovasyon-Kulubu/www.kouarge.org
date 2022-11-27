namespace KouArge.Core.Models
{
    public class Speaker : BaseEntity
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string? ImgUrl { get; set; }
        public Event Event { get; set; }
    }
}
