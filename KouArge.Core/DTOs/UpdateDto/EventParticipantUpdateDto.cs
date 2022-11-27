namespace KouArge.Core.DTOs.UpdateDto
{
    public class EventParticipantUpdateDto : UpdateDto
    {
        public int EventId { get; set; }
        public string AppUserId { get; set; }
    }
}
