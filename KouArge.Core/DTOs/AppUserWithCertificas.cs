namespace KouArge.Core.DTOs
{
    public class AppUserWithCertificas : StringBaseDto
    {
        //public string AppUserId { get; set; }
        //public int EventId { get; set; }
        public int Template { get; set; }
        public AppUserBasicDto AppUser { get; set; }
        public EventDto Event { get; set; }
    }
}
