using KouArge.Core.Models;

namespace KouArge.Core.DTOs
{
    public class DepartmentWithFacultyDto: DepartmentDto
    {
        public FacultyDto Faculty { get; set; }

    }
}
