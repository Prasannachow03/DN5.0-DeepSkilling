using Microsoft.AspNetCore.Mvc;
using HOL1_BasicWebAPI.Models;

namespace HOL1_BasicWebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private static List<Student> _students = new()
    {
        new Student { Id = 1, Name = "Alice", Course = "DotNet", Age = 21 },
        new Student { Id = 2, Name = "Bob",   Course = "React",  Age = 22 },
        new Student { Id = 3, Name = "Carol",  Course = "SQL",    Age = 20 }
    };

    [HttpGet]
    public ActionResult<IEnumerable<Student>> GetAll() => Ok(_students);

    [HttpGet("{id}")]
    public ActionResult<Student> GetById(int id)
    {
        var s = _students.FirstOrDefault(x => x.Id == id);
        return s == null ? NotFound() : Ok(s);
    }

    [HttpPost]
    public ActionResult<Student> Create(Student student)
    {
        student.Id = _students.Max(x => x.Id) + 1;
        _students.Add(student);
        return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
    }
}