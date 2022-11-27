namespace KouArge.Core.DTOs.UpdateDto
{
    public class DepartmentUpdateDto
    {
        public string Id { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public int FacultyId { get; set; }
    }
}
