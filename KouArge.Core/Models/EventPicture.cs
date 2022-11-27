namespace KouArge.Core.Models
{
    public class EventPicture : BaseEntity
    {
        public int EventId { get; set; }
        public string ImgUrl { get; set; }

        public Event Event { get; set; }
    }
}
