namespace KouArge.Core.DTOs
{
    public class SocialMediaPostDto : BaseDto
    {
        public int TeamMemberId { get; set; }
        public string? Url { get; set; }
        public int SocaialMediaTypeId { get; set; }

        public string Token { get; set; }
    }
}
