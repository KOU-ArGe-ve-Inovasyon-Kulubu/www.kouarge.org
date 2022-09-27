namespace KouArge.Core.Models
{
    public class EventParticipant : BaseEntity
    {
        public int EventId { get; set; }
        public int UserId { get; set; }

        public Event Event { get; set; }

        //public IEnumerable<Event> Events { get; set; }
        public ICollection<GeneralAssemblyApply> GeneralAssemblyApplies { get; set; }

    }
}
