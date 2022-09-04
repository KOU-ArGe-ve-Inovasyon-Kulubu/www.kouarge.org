using KouArge.Core.Models;

namespace KouArge.Core.DTOs
{
    public class DepartmentDto:BaseDto
    {
        public string Name { get; set; }
        public int FacultyId { get; set; }
    }
}
