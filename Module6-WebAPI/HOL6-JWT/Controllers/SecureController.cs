using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HOL6_JWT.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class SecureController : ControllerBase
{
    [HttpGet]
    public IActionResult GetSecureData()
        => Ok("This is protected data — only JWT authenticated users can see this!");
}