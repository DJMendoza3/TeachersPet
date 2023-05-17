namespace TeachersPet.Entities;

public class Question
{
    public int Id { get; set; }
    public string Text { get; set; } = null!;
    public ICollection<Answer> Answers { get; set; } = null!;
}