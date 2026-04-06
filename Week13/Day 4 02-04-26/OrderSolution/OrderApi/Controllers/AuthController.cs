using Microsoft.AspNetCore.Mvc;
using OrderApi.Models;
using OrderApi.Services;

namespace OrderApi.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokenService;

        public AuthController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        /// <summary>
        /// Login and get a JWT token.
        /// Admin credentials: admin / admin123
        /// User credentials:  user  / user123
        /// </summary>
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            // In a real app you would check a database here.
            // Hardcoded for learning purposes only.
            if (dto.Username == "admin" && dto.Password == "admin123")
            {
                var token = _tokenService.GenerateToken(dto.Username, "Admin");
                return Ok(new LoginResponseDto
                {
                    Token     = token,
                    Username  = dto.Username,
                    Role      = "Admin",
                    ExpiresAt = DateTime.UtcNow.AddHours(1)
                });
            }

            if (dto.Username == "user" && dto.Password == "user123")
            {
                var token = _tokenService.GenerateToken(dto.Username, "User");
                return Ok(new LoginResponseDto
                {
                    Token     = token,
                    Username  = dto.Username,
                    Role      = "User",
                    ExpiresAt = DateTime.UtcNow.AddHours(1)
                });
            }

            return Unauthorized(new { message = "Invalid username or password." });
        }
    }
}
