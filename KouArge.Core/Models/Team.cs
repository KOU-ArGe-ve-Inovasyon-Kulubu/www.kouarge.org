namespace KouArge.Core.Models
{
    public class Team:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string LogoUrl { get; set; }
        public ICollection<TeamMember> teamMembers { get; set; }
    }
}
