namespace KouArge.Core.Models
{
    public class GeneralAssembly : BaseEntity
    {
        public string UserId { get; set; }
        public string? PıctureUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Status { get; set; }

        //public ICollection<AppUser> Users { get; set; }
        public AppUser User { get; set; }
        public ICollection<Team> Teams { get; set; }
        public ICollection<TeamMember> TeamMembers { get; set; }

    }
}
