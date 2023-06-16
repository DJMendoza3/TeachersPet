using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeachersPet.Entities;

public class Test
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public string TestName { get; set; } = null!;
    [Required]
    public int GradeLevel { get; set; } = 0;
    [Required]
    public int SubjectId { get; set; } = 0;
    [Required]
    public string Topic { get; set; } = null!;
    [Required]
    //validate this for 2 decimal places at some point
    public float Difficulty { get; set; } = 0;
    [Required]
    public string Text { get; set; } = null!;
    public ICollection<Question> Questions { get; set; } = null!;
}