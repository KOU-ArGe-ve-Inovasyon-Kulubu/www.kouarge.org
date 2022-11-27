namespace KouArge.Core.DTOs
{
    public abstract class BaseDto
    {
        public int Id { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; }
    }
}
