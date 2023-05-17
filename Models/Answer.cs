namespace TeachersPet.Models;

public class Answer 
{
    public int Id { get; set; }
    public string Text { get; set; } = null!;
    public bool IsCorrect { get; set; }
}