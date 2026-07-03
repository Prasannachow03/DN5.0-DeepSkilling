using System.ComponentModel.DataAnnotations;

namespace HOL3_Validation.Models;
public class Employee
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [StringLength(50, MinimumLength = 2)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string Email { get; set; } = string.Empty;

    [Range(18, 65, ErrorMessage = "Age must be between 18 and 65")]
    public int Age { get; set; }

    [Required]
    public string Department { get; set; } = string.Empty;
}