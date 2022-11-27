namespace KouArge.Core.Models
{
    public class SocialMedia : BaseEntity
    {
        //public int generalAssemblyId { get; set; }

        public int TeamMemberId { get; set; }
        public string? Url { get; set; }
        public int SocaialMediaTypeId { get; set; }
        public SocialMediaType SocaialMediaType { get; set; }
        //public GeneralAssembly GeneralAssembly { get; set; }
        public TeamMember TeamMember { get; set; }
    }
}
