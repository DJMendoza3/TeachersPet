namespace TeachersPet.Entities;

public class Test
{
    public int Id { get; set; }
    public string Text { get; set; } = null!;
    public ICollection<Question> Questions { get; set; } = null!;
}