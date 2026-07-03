using Microsoft.AspNetCore.Mvc;

namespace HOL5_Middleware.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll() => Ok(new[] { "Order1", "Order2", "Order3" });

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        if (id <= 0) throw new ArgumentException("Invalid order ID");
        if (id > 10) return NotFound("Order not found");
        return Ok($"Order {id}");
    }
}