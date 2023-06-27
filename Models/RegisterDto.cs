using System.ComponentModel.DataAnnotations;

namespace TeachersPet.Models;

public class RegisterDto
{
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public string Username { get; set; } = null!;
    [Required]
    public string Password { get; set; } = null!;
    [Required]
    public string Email { get; set; } = null!;
    [Required, Range(0, 2)] 
    public int Role { get; set; }
}