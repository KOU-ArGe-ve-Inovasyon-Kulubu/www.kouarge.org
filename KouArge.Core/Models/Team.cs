namespace KouArge.Core.Models
{
    public class Team : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public ICollection<TeamMember> TeamMembers { get; set; }

        //public ICollection<GeneralAssembly> GeneralAssemblies { get; set; }
        public ICollection<GeneralAssemblyApply> GeneralAssemblyApplies { get; set; }
    }
}
