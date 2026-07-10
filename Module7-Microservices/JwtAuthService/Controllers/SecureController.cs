using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthService.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class SecureController : ControllerBase
{
    // Only accessible with valid JWT token
    [HttpGet("data")]
    public IActionResult GetData()
    {
        var username = User.Identity?.Name;
        var role = User.FindFirst(System.Security.Claims.ClaimTypes.Role)?.Value;
        return Ok(new
        {
            message = "You accessed protected Microservice data!",
            user = username,
            role = role
        });
    }

    // Only Admin role can access
    [HttpGet("admin")]
    [Authorize(Roles = "Admin")]
    public IActionResult AdminOnly()
        => Ok(new { message = "Welcome Admin! This is an admin-only microservice endpoint." });
}