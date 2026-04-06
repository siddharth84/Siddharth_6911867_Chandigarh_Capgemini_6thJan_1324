using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ECommerce.API.DTOs;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly TokenService _tokenService;
    private readonly AppDbContext _context;

    public AuthController(TokenService tokenService, AppDbContext context)
    {
        _tokenService = tokenService;
        _context = context;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var role = dto.Username == "admin" ? "Admin" : "User";

        var accessToken = _tokenService.GenerateToken(dto.Username, role);
        var refreshToken = _tokenService.GenerateRefreshToken();

        _context.RefreshTokens.Add(new RefreshToken
        {
            Token = refreshToken,
            ExpiryDate = DateTime.Now.AddDays(7)
        });

        await _context.SaveChangesAsync();

        return Ok(new { accessToken, refreshToken });
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh(TokenRequest request)
    {
        var stored = await _context.RefreshTokens
            .FirstOrDefaultAsync(x => x.Token == request.RefreshToken);

        if (stored == null || stored.ExpiryDate < DateTime.Now)
            return Unauthorized();

        var newToken = _tokenService.GenerateToken("user", "User");

        return Ok(new { accessToken = newToken });
    }
}