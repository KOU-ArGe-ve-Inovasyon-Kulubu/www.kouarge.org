using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Core.DTOs
{
    public abstract class StringBaseDto
    {
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
