namespace KouArge.Core.DTOs
{
    public class AppUserWithApplyDto : BaseDto
    {
        public string AppUserId { get; set; }
        public int TeamId { get; set; }
        public int TitleId { get; set; }
        public string Introducing { get; set; }
        public string Why { get; set; }
        public string SituationDescription { get; set; }
        public int AppStatus { get; set; } //ToDo : Enum eklenecek
        public DateTime ApplyTime { get; set; }
        public TeamDto Team { get; set; }
        public TitleDto Title { get; set; }

    }
}
