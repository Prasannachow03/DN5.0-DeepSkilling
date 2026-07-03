using Microsoft.AspNetCore.Mvc;

namespace HOL2_Routing.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private static List<string> _products = new() { "Laptop", "Phone", "Tablet" };

    [HttpGet]
    public IActionResult GetAll() => Ok(_products);

    [HttpGet("search")]
    public IActionResult Search([FromQuery] string name)
    {
        var result = _products.Where(p => p.Contains(name, StringComparison.OrdinalIgnoreCase));
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        if (id < 1 || id > _products.Count) return NotFound("Product not found");
        return Ok(_products[id - 1]);
    }

    [HttpPost]
    public IActionResult Add([FromBody] string product)
    {
        _products.Add(product);
        return Ok($"Added: {product}");
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        if (id < 1 || id > _products.Count) return NotFound();
        _products.RemoveAt(id - 1);
        return Ok("Deleted successfully");
    }
}