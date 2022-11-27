namespace KouArge.Core.DTOs
{
    public class TeamMemberDto : BaseDto
    {
        public string AppUserId { get; set; }
        public int TitleId { get; set; }
        public int GeneralAssemblyApplyId { get; set; }
        public int TeamId { get; set; }
        public string ImgUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
