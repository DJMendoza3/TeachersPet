namespace TeachersPet.Models;

public class TestDto
{
    public string Text { get; set; } = null!;
    public ICollection<QuestionDto> Questions { get; set; } = null!;
}