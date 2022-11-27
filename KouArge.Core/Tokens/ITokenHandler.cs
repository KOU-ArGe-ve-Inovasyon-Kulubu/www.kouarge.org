using KouArge.Core.DTOs;
using System.Security.Claims;

namespace KouArge.Core.Tokens
{
    public interface ITokenHandler
    {
        Token CreateAccessToken(int minute, List<string> roles, string userId);
        string CreateRefreshToken();
        List<Claim> DecodeToken(string token);
    }
}
