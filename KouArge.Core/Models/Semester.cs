namespace KouArge.Core.Models
{
    public class Semester : BaseEntity
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public ICollection<Event> Events { get; set; }
    }
}
