using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Core.DTOs
{
    public class EventParticipantWithUserDto:BaseDto
    {
        public int EventId { get; set; }
        public string AppUserId { get; set; }
        public AppUserBasicDto AppUser { get; set; }
    }
}
