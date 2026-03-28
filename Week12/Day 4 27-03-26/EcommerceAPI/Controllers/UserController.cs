using Microsoft.AspNetCore.Mvc;
using log4net;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private static readonly ILog log = LogManager.GetLogger(typeof(UserController));

    [HttpPost("login")]
    public IActionResult Login(string email, string password)
    {
        try
        {
            log.Info($"Login attempt: {email}");

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                log.Warn("Invalid input data");
                return BadRequest("Invalid input");
            }

            if (password != "1234")
            {
                log.Warn("Invalid password");
                return Unauthorized();
            }

            return Ok("Login successful");
        }
        catch (Exception ex)
        {
            log.Error("Login exception", ex);
            return StatusCode(500);
        }
    }
}