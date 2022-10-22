using KouArge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Core.DTOs
{
    public class EventParticipantDto:BaseDto
    {
        public int EventId { get; set; }
        public int UserId { get; set; }
    }
}
