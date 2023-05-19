using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeachersPet.Entities;

public class Answer 
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Text { get; set; } = null!;
    public bool IsCorrect { get; set; }
}