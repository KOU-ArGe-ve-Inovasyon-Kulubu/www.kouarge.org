using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KouArge.Core.DTOs
{
    public class AppUserLoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }

        [JsonIgnore]
        public List<string> Errors { get; set; }

        [JsonIgnore]
        public int ErrorStatus { get; set; }
    }
}
