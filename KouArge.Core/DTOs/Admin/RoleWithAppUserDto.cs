namespace KouArge.Core.DTOs.Admin
{
    public class RoleWithAppUserDto
    {
        public string Id { get; set; }
        public string RoleName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string StudentNumber { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
        public int Year { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
