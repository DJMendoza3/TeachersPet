using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeachersPet.Entities;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;
    public ICollection<Test> Tests { get; set; } = new List<Test>();
}