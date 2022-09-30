using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KouArge.Core.DTOs
{
    public class AppUserRegisterDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string StudentNo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int DepartmentId { get; set; }
        public int Year { get; set; }
        public int Status { get; set; }

        [JsonIgnore]
        public List<string> Errors { get; set; }

        [JsonIgnore]
        public int ErrorStatus { get; set; }

    }
}
