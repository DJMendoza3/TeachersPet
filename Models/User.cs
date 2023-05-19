using System.ComponentModel.DataAnnotations;

namespace TeachersPet.Models;

public class User 
{
    [Required, MaxLength(30)]
    public string Name { get; set; } = null!;
    [Required, MaxLength(50)]
    public string Username { get; set; } = null!;
    [Required, MaxLength(50)]
    public string Password { get; set; } = null!;

    public ICollection<Test> Tests { get; set; } = null!;
}