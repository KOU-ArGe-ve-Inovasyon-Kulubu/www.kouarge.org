using System.Text.Json.Serialization;

namespace KouArge.Core.DTOs
{
    public class AppUserLoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }

        [JsonIgnore]
        public int ErrorStatus { get; set; }
    }
}
