using KouArge.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KouArge.Core.DTOs
{
    public class RedirectDto : BaseEntity
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public int Status { get; set; }
        public int Count { get; set; }
    }
}
