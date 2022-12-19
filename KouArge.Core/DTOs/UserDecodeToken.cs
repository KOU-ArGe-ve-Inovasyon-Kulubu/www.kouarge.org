using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Core.DTOs
{
    public class UserDecodeToken
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public string StudentNumber { get; set; } 
        public List<string> Roles { get; set; }

        public List<Claim> Claims { get; set; }
    }
}
