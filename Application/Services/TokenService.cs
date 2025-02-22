using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ASbackend.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace ASbackend.Application.Services
{
    public class TokenService
    {
        private readonly string _secretKey;

        public TokenService(IConfiguration configuration)
        {
            _secretKey = configuration["JwtSettings:SecretKey"]!;
        }
        public string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {

                Subject = new ClaimsIdentity(new[]
                {
                    new Claim (ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim (ClaimTypes.Name, user.fullname),
                }),

                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var AcessToken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(AcessToken);
        }
    }
}