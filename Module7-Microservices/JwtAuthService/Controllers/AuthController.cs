using JwtAuthService.Models;
using JwtAuthService.Services;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService) => _authService = authService;

    // Question 1: Register User
    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var result = _authService.Register(request);
        return Ok(new { message = result });
    }

    // Question 1: Login and get JWT Token
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var result = _authService.Login(request);

        if (result == "Invalid username or password.")
            return Unauthorized(new { message = result });

        return Ok(new { token = result });
    }
}