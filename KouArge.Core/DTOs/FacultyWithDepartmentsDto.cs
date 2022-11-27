namespace KouArge.Core.DTOs
{
    public class FacultyWithDepartmentsDto : FacultyDto
    {
        public ICollection<DepartmentDto> Departments { get; set; }
    }
}
