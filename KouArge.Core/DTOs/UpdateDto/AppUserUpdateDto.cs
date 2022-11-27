namespace KouArge.Core.DTOs.UpdateDto
{
    public class AppUserUpdateDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string StudentNumber { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string DepartmentId { get; set; }
        public int Year { get; set; }
        public bool IsActive { get; set; }
        public int NotificationId { get; set; }
        public string AccessToken { get; set; }

    }
}
