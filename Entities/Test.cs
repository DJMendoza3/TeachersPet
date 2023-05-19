using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeachersPet.Entities;

public class Test
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Text { get; set; } = null!;
    public ICollection<Question> Questions { get; set; } = null!;
}