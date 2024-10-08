using Application.Configuration;
using Application.DTO;
using Application.Interfaces;
using Domain.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        public AuthService(IUserService userService) 
        {
            _userService = userService;
        }    
        public async Task<string> LoginAsync(LoginDTO loginDTO)
        {
            var users = await _userService.GetUserAccounts();

            var user = users.SingleOrDefault(x =>
            x.UserAccountCredentials.Email.Equals(loginDTO.Email, StringComparison.OrdinalIgnoreCase) &&
            BCrypt.Net.BCrypt.Verify(loginDTO.Password, x.UserAccountCredentials.Password));

            if (user == null)
                throw new Exception("CPLM p word ?");

            // Creează și returnează un token JWT
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(GlobalSettings.SECRET_KEY);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
