using Microsoft.AspNetCore.Mvc;
using HOL3_Validation.Models;

namespace HOL3_Validation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private static List<Employee> _employees = new();

    [HttpGet]
    public ActionResult<IEnumerable<Employee>> GetAll() => Ok(_employees);

    [HttpPost]
    public ActionResult<Employee> Create([FromBody] Employee employee)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        employee.Id = _employees.Count + 1;
        _employees.Add(employee);
        return CreatedAtAction(nameof(GetAll), new { id = employee.Id }, employee);
    }

    [HttpGet("{id}")]
    public ActionResult<Employee> GetById(int id)
    {
        var emp = _employees.FirstOrDefault(e => e.Id == id);
        return emp == null ? NotFound() : Ok(emp);
    }
}