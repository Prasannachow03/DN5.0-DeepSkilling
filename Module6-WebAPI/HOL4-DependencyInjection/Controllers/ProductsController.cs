using Microsoft.AspNetCore.Mvc;
using HOL4_DependencyInjection.Services;

namespace HOL4_DependencyInjection.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    public ProductsController(IProductService service) => _service = service;

    [HttpGet]
    public IActionResult GetAll() => Ok(_service.GetAll());

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var product = _service.GetById(id);
        return product == null ? NotFound() : Ok(product);
    }

    [HttpPost]
    public IActionResult Add([FromBody] string product)
    {
        _service.Add(product);
        return Ok($"Added: {product}");
    }
}