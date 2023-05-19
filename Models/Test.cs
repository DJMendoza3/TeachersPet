namespace TeachersPet.Models;

public class Test
{
    public string Text { get; set; } = null!;
    public ICollection<Question> Questions { get; set; } = null!;
}