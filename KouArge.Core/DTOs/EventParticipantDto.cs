namespace KouArge.Core.DTOs
{
    public class EventParticipantDto : BaseDto
    {
        public int EventId { get; set; }
        public string AppUserId { get; set; }

        public string Token { get; set; }
    }
}
