namespace KouArge.Core.DTOs
{
    public class AppUserWithTeamDto : BaseDto
    {
        public AppUserBasicDto AppUser { get; set; }
        public string AppUserId { get; set; }
        public int GeneralAssemblyApplyId { get; set; }
        public int TeamId { get; set; }
        public int TitleId { get; set; }
        public string ImgUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TitleDto Title { get; set; }
        public TeamDto Team { get; set; }

    }
}
