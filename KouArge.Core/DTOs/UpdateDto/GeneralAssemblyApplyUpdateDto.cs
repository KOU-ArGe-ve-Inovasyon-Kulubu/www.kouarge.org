namespace KouArge.Core.DTOs.UpdateDto
{
    public class GeneralAssemblyApplyUpdateDto : UpdateDto
    {
        public int TeamId { get; set; }
        public string AppUserId { get; set; }
        public int TitleId { get; set; }
        public string Introducing { get; set; }
        public string Why { get; set; }
        public string SituationDescription { get; set; }
        public int AppStatus { get; set; } //ToDo : Enum eklenecek
        public DateTime ApplyTime { get; set; }
    }
}
