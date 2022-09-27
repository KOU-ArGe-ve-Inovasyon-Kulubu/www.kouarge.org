using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Core.DTOs.Admin
{
    public class RoleWithAppUserDto
    {
        public string Id { get; set; }
        public string RoleName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string StudentNo { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
        public int Year { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
