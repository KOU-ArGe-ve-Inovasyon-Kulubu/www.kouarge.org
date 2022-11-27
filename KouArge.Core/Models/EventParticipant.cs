namespace KouArge.Core.Models
{
    public class EventParticipant : BaseEntity
    {
        public int EventId { get; set; }
        public string AppUserId { get; set; }
        public Event Event { get; set; }

        //public IEnumerable<Event> Events { get; set; }

        public AppUser AppUser { get; set; }

    }
}
