using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using EasyLiving.Application.Commom.Interfaces.Services;
using EasyLiving.Application.Common.Interfaces.Auth;
using Microsoft.IdentityModel.Tokens;

namespace EasyLiving.Infrastructure.Auth
{
    public class JwtToken : IJwtToken
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        
        public JwtToken(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }
        public string GenerateToken(Guid userId, string email, string role, string secret)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey("a_random_32_character_string_here_aaaa"u8.ToArray());
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                    new Claim(ClaimTypes.Email, email),
                    new Claim(ClaimTypes.Role, role)
                }),
                Issuer = "EasyLiving",
                Expires = _dateTimeProvider.UtcNow.AddMinutes(60),
                Audience = "",
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
