namespace TeachersPet.Entities;

public class Test
{
    public int Id { get; set; }
    public string Text { get; set; } = null!;
    public List<Question> Questions { get; set; } = null!;
}