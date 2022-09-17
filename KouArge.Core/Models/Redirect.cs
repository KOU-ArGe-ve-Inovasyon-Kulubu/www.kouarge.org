using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Core.Models
{
    public class Redirect
    {
        [Key]
        public string Id { get; set; }
        public int Count { get; set; }
        public string Url { get; set; }
    }
}
