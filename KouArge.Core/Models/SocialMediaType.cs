namespace KouArge.Core.Models
{
    public class SocialMediaType:BaseEntity
    {
        public string Name { get; set; }
        public string Icon { get; set; }

        public SocialMedia SocialMedia { get; set; }

    }
}
