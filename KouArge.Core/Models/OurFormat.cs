namespace KouArge.Core.Models
{
    public class OurFormat : BaseEntity
    {
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public ICollection<Event> Event { get; set; }
    }
}
