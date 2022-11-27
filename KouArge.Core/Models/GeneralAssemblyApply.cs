namespace KouArge.Core.Models
{
    public class GeneralAssemblyApply : BaseEntity
    {
        public string AppUserId { get; set; }
        public int TeamId { get; set; }
        public int TitleId { get; set; }
        public string Introducing { get; set; }
        public string Why { get; set; }
        public string SituationDescription { get; set; }
        public int AppStatus { get; set; } = 0; //ToDo : Enum eklenecek
        public DateTime ApplyTime { get; set; }
        public Team Team { get; set; }
        //public ICollection<AppUser> Users { get; set; }//?? bak
        public AppUser AppUser { get; set; }
        //public//eneralAssembly GeneralAssembly { get; set; }
        public Title Title { get; set; }

        public ICollection<TeamMember> TeamMembers { get; set; }
        //public ICollection<GeneralAssembly> GeneralAssemblies { get; set; }

    }
}
