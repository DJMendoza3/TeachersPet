using System.ComponentModel.DataAnnotations;

namespace TeachersPet.Models;

public class User 
{
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(30)]
    public string Name { get; set; } = null!;
    [Required, MaxLength(50)]
    public string Email { get; set; } = null!;

    public ICollection<Test> Tests { get; set; } = null!;
}