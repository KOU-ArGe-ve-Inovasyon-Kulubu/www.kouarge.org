namespace KouArge.Core.Models
{
    public class SocialMedia:BaseEntity
    {
        public int Fk { get; set; }
        public string? Link { get; set; }
        public int TypeId { get; set; }

        public ICollection<SocialMediaType> SocaialMediaType { get; set; }
    }
}
