using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Core.DTOs.UpdateDto
{
    public class EventPictureUpdateDto
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string? Url { get; set; }
    }
}
