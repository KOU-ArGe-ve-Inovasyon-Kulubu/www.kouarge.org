using KouArge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Core.DTOs
{
    public class EventDto:BaseDto
    {
        public int FormatId { get; set; }
        public int SemesterId { get; set; }
        public int OurFormatId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Speaker { get; set; }
        public DateTime EventDate { get; set; }
        public string Url { get; set; }

    }
}
