namespace TeachersPet.Models;

public class Question
{
    public int Id { get; set; }
    public string Text { get; set; } = null!;
    public List<Answer> Answers { get; set; } = null!;
}