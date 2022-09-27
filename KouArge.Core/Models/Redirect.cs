using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Core.Models
{
    public class Redirect : BaseEntity
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public string Url { get; set; }
        public int Status { get; set; }
    }
}
