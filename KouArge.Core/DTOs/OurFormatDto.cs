using KouArge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Core.DTOs
{
    public class OurFormatDto:BaseDto
    {
        public string Name { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string Type { get; set; }
    }
}
