using System.Text.Json.Serialization;

namespace KouArge.Core.DTOs
{
    public class Token
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime Expiration { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
        [JsonIgnore]
        public List<string> Errors { get; set; } = new List<string>();
    }
}
