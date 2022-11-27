namespace KouArge.Core.DTOs.UpdateDto
{
    public class TeamMemberUpdateDto : UpdateDto
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
