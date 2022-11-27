namespace KouArge.Core.DTOs.UpdateDto
{
    public class CertificateUpdateDto
    {
        public string Id { get; set; }
        public bool IsActive { get; set; } = true;
        public int Template { get; set; }
        public string AppUserId { get; set; }
        public int EventId { get; set; }
        public string Token { get; set; }
    }
}
