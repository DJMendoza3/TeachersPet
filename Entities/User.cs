using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TeachersPet.Entities;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string Email { get; set; }
    public double Credits { get; set; }
    [Required]
    public Role UserRole { get; set; }
    public ICollection<Test> Tests { get; set; }
    public School School { get; set; }
    public ICollection<Course> Courses { get; set; }

}