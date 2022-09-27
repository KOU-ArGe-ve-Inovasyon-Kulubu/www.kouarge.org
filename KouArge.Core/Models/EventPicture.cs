namespace KouArge.Core.Models
{
    public class EventPicture : BaseEntity
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string? Url { get; set; }

        public Event Event { get; set; }
    }
}
