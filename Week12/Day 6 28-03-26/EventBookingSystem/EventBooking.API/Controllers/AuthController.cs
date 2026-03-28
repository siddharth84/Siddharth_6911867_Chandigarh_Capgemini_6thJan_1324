using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _config;

    public AuthController(IConfiguration config)
    {
        _config = config;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        if (request == null || string.IsNullOrEmpty(request.Username))
            return BadRequest("Invalid request");

        string role = "";
        // Use ToLower() to handle case sensitivity during the check
        string normalizedUser = request.Username.Trim().ToLower();

        if (normalizedUser == "admin" && request.Password == "password")
        {
            role = "Admin";
        }
        else if (normalizedUser == "user" && request.Password == "password")
        {
            role = "Client";
        }
        else
        {
            return Unauthorized(new { message = "Invalid credentials" });
        }

        // Generate Token
        var jwtKey = _config["Jwt:Key"] ?? "ThisIsADefaultSecretKeyThatIsAtLeast32CharsLong!";
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, request.Username),
            new Claim(ClaimTypes.Role, role)
        };

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds
        );

        return Ok(new 
        { 
            token = new JwtSecurityTokenHandler().WriteToken(token),
            role = role 
        });
    }
}

public class LoginRequest 
{
    public string Username { get; set; }
    public string Password { get; set; }
}