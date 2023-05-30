using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeachersPet.Entities;

public class GeneratorSettings
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Subject { get; set; } = null!;
    [Required]
    public string Topic { get; set; } = null!;
    [Required]
    public int Grade { get; set; } = 5;
    [Required]
    public int NumberOfQuestions { get; set; } = 10;
    [Required]
    public int NumberOfAnswers { get; set; } = 4;
    [Required]
    public int PercentageOfDifficulty { get; set; } = 50;
}