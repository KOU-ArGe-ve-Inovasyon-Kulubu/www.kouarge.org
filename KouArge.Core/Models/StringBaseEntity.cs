namespace KouArge.Core.Models
{
    public abstract class StringBaseEntity
    {
        public string Id { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
