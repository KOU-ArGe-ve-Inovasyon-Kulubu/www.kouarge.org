namespace KouArge.Core.Models
{
    public class Certificate : StringBaseEntity
    {
        public string AppUserId { get; set; }
        public int EventId { get; set; }
        public int Template { get; set; }
        public AppUser AppUser { get; set; }

        public Event Event { get; set; }
    }
}
