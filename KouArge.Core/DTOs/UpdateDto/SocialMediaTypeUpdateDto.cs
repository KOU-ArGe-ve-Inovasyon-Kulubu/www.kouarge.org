using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Core.DTOs.UpdateDto
{
    public class SocialMediaTypeUpdateDto
    {
        public int Id { get; set; }
        public int Fk { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
    }
}
