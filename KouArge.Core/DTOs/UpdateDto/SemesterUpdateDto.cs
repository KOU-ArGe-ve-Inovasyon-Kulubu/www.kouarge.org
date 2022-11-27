namespace KouArge.Core.DTOs.UpdateDto
{
    public class SemesterUpdateDto : UpdateDto
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
