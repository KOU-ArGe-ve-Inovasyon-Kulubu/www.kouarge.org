using KouArge.Core.DTOs;
using KouArge.Core.Models;
using System.Security.Claims;

namespace KouArge.Core.Tokens
{
    public interface ITokenHandler
    {
        Token CreateAccessToken(int minute, List<string> roles, AppUser user);
        string CreateRefreshToken();
        List<Claim> DecodeToken(string Token);
    }
}
