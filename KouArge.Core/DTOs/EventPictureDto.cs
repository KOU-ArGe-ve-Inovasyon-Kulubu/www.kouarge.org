using KouArge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Core.DTOs
{
    public class EventPictureDto:BaseDto
    {
        public int EventId { get; set; }
        public string? Url { get; set; }
    }
}
