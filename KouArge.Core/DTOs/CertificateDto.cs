namespace KouArge.Core.DTOs
{
    public class CertificateDto : StringBaseDto
    {
        public string AppUserId { get; set; }
        public int EventId { get; set; }
        public int Template { get; set; }
        public string Token { get; set; }
    }
}
