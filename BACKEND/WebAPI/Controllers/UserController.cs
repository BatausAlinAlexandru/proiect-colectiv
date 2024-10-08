using Application.DTO;
using Domain.Entities.User;
using Application.Interfaces;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Domain.Services;
namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;

        public UserController(IUserService userService, IAuthService tokenService)
        {
            _userService = userService;
            _authService = tokenService;
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public async Task<List<UserAccount>> GetUserCredentials()
        {
            return await _userService.GetUserAccounts();
        }

        [HttpPost]
        public async Task AddUserCredentials(UserAccount userCredentials)
        {
            await _userService.AddUserCredentials(userCredentials);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDTO loginDTO)
        {
            var token =  _authService.LoginAsync(loginDTO);
            return Ok(new { Token = token });

        }
    }
}
