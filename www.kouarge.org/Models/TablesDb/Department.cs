using Microsoft.EntityFrameworkCore;
using www.kouarge.org.Identity;

namespace www.kouarge.org.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int FacultyID { get; set; }

    }
}
