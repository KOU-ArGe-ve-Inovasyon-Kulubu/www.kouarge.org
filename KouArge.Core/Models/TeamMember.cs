namespace KouArge.Core.Models
{
    public class TeamMember:BaseEntity
    {
        public int GeneralAssemblyId { get; set; }
        public int TeamId { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<Team> Teams { get; set; }
        public ICollection<GeneralAssembly> GeneralAssemblies { get; set; }
    }
}
