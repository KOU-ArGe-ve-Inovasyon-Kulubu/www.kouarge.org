using System.Text.Json.Serialization;

namespace KouArge.Core.DTOs
{
    public class AppUserDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string StudentNo { get; set; }
        public string Email { get; set; }
        public string DepartmentId { get; set; }
        public int Year { get; set; } 
        public int Status { get; set; }
        public int NotificationId { get; set; }
        public DateTime CreatedAt { get; set; }

        public Token Token { get; set; }


        [JsonIgnore]
        public List<string> Errors { get; set; }

        [JsonIgnore]
        public int ErrorStatus { get; set; }

    }
}
