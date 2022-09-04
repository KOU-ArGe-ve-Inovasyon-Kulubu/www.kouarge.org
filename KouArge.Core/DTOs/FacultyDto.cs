using KouArge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Core.DTOs
{
    public class FacultyDto:BaseDto
    {
        public string Name { get; set; }
        public string Campus { get; set; }
    }
}
