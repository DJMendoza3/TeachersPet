namespace TeachersPet.Models;

public class Question
{
    public string Text { get; set; } = null!;
    public ICollection<Answer> Answers { get; set; } = null!;
}