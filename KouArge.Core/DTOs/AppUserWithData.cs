namespace KouArge.Core.DTOs
{
    public class AppUserWithData
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string StudentNumber { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string DepartmentId { get; set; }
        public int Year { get; set; }
        public bool IsActive { get; set; }
        public int NotificationId { get; set; }
        public DateTime CreatedAt { get; set; }

        public DepartmentDto Department { get; set; }

    }
}
