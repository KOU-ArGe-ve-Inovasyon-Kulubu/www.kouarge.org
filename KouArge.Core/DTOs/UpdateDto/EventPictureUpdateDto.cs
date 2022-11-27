namespace KouArge.Core.DTOs.UpdateDto
{
    public class EventPictureUpdateDto : UpdateDto
    {
        public int EventId { get; set; }
        public string? ImgUrl { get; set; }
    }
}
