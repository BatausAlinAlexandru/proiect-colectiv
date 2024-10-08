using Application.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Application.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Application.DTO;
namespace Application.Services
{
    public class TokenService : ITokenService
    {
        public string GenerateToken(GenerateTokenDTO generateTokenDTO)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, generateTokenDTO.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, generateTokenDTO.Id.ToString()),
                new Claim(ClaimTypes.Role, generateTokenDTO.Role.ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(GlobalSettings.SECRET_KEY));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
            issuer: "localhost",
            audience: "localhost",
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds
        );
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
