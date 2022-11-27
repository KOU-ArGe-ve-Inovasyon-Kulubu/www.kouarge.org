namespace KouArge.Core.DTOs
{
    public class SocialMediaDto : BaseDto
    {
        public int TeamMemberId { get; set; }
        public string? Url { get; set; }
        public int SocaialMediaTypeId { get; set; }
        public SocialMediaTypeDto SocaialMediaType { get; set; }
        public TeamMemberDto TeamMember { get; set; }
    }
}
