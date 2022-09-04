namespace KouArge.Core.Models
{
    public class SponsorsAndPartners:BaseEntity
    {
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<SocialMedia> SocialMedias { get; set; }
    }
}
