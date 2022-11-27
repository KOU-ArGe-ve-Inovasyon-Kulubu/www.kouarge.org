namespace KouArge.Core.DTOs
{
    public class GeneralAssemblyApplyDto : BaseDto
    {
        public int TeamId { get; set; }
        public string AppUserId { get; set; }

        public int TitleId { get; set; }
        public string Introducing { get; set; }
        public string Why { get; set; }
        public string SituationDescription { get; set; }
        public int AppStatus { get; set; } = 0;//ToDo : Enum eklenecek
        public DateTime ApplyTime { get; set; }

        public string Token { get; set; }

    }
}
