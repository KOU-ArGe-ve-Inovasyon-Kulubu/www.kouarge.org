using KouArge.Core.DTOs;
using KouArge.Core.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Concurrent;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace KouArge.Service.Services.Tokens
{
    public class TokenHandler : ITokenHandler
    {
        readonly IConfiguration _configruation;

        public TokenHandler(IConfiguration configruation)
        {
            _configruation = configruation;
        }

        public Token CreateAccessToken(int minute, List<string> roles, string userId)
        {
            Token token = new();

            //Security key in simetrik değerinin alıyoruz
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configruation["Token:SecurityKey"]));

            //Sifrelemenmis kimligi oluşturuyoruz.
            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            //oluşturulacak token ayarlarını veriyoruz
            token.Expiration = DateTime.UtcNow.AddSeconds(minute);

            //claims
            var claims = new List<Claim>();
            if (roles.Count != 0)
                foreach (var item in roles)
                    claims.Add(new Claim(ClaimTypes.Role, item));

            claims.Add(new Claim("userId", userId));

            JwtSecurityToken securityToken = new(
                audience: _configruation["Token:Audience"],
                issuer: _configruation["Token:Issuer"],
                expires: token.Expiration,
                claims: claims,
                notBefore: DateTime.UtcNow,//token uretildinde ne zaman sonra devreye girsin
                signingCredentials: signingCredentials //key
                );

            //Token oluşturucu sınıfından ornek alındı
            JwtSecurityTokenHandler tokenHandler = new();
            token.AccessToken = tokenHandler.WriteToken(securityToken);
            token.RefreshToken = CreateRefreshToken();
            return token;
        }

        public string CreateRefreshToken()
        {
            ConcurrentDictionary<string, Guid> _refreshToken = new ConcurrentDictionary<string, Guid>();
            Guid refreshToken = _refreshToken.AddOrUpdate("uid", x => Guid.NewGuid(), (x, o) => Guid.NewGuid());
            return refreshToken.ToString();

            //byte[] number = new byte[32];
            //using RandomNumberGenerator rnd = RandomNumberGenerator.Create();
            //rnd.GetBytes(number);
            //return Convert.ToBase64String(number);
        }
    }
}
