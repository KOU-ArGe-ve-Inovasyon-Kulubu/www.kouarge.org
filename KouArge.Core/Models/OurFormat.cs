namespace KouArge.Core.Models
{
    public class OurFormat : BaseEntity
    {
        public string Name { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string Type { get; set; }
        public Event Event { get; set; }
    }
}
