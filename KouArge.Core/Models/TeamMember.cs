namespace KouArge.Core.Models
{
    public class TeamMember : BaseEntity
    {
        public string AppUserId { get; set; }

        //public int GeneralAssemblyId { get; set; }
        public int GeneralAssemblyApplyId { get; set; }
        public int TeamId { get; set; }
        public int TitleId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ImgUrl { get; set; }
        public Title Title { get; set; }
        public AppUser AppUser { get; set; }

        public Team Team { get; set; }
        public GeneralAssemblyApply GeneralAssemblyApply { get; set; }
        //public ICollection<AppUser> AppUsers { get; set; }
        //public ICollection<Team> Teams { get; set; }
        //public ICollection<GeneralAssemblyApply> GeneralAssemblyApplies { get; set; }
        public ICollection<SocialMedia> SocialMedias { get; set; }

        //public ICollection<GeneralAssembly> GeneralAssemblies { get; set; }
    }
}
