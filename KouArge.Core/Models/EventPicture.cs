namespace KouArge.Core.Models
{
    public class EventPicture : BaseEntity
    {
        public int EventId { get; set; }
        public string? Url { get; set; }

        public Event Event { get; set; }
    }
}
