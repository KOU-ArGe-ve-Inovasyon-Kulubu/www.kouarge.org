using System.Text.Json.Serialization;

namespace KouArge.Core.DTOs
{
    public class AppUserDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string StudentNumber { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string DepartmentId { get; set; }
        public int Year { get; set; }
        public bool IsActive { get; set; } = true;
        public int NotificationId { get; set; }
        public DateTime CreatedAt { get; set; }

        public DepartmentDto Department { get; set; }

        public Token Token { get; set; }

        //[JsonIgnore]
        public List<ErrorViewModel> Errors { get; set; }

        //[JsonIgnore]
        //public int ErrorStatus { get; set; }

    }
}
