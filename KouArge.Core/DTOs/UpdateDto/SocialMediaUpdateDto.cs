namespace KouArge.Core.DTOs.UpdateDto
{
    public class SocialMediaUpdateDto : UpdateDto
    {
        public int TeamMemberId { get; set; }
        public string? Url { get; set; }
        public int SocaialMediaTypeId { get; set; }

        public string Token { get; set; }
    }
}
