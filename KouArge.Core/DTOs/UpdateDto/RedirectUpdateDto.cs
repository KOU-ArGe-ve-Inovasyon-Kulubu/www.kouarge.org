namespace KouArge.Core.DTOs.UpdateDto
{
    public class RedirectUpdateDto : UpdateDto
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public bool IsActive { get; set; }
        public int Count { get; set; }
    }
}
