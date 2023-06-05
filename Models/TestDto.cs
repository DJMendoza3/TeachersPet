namespace TeachersPet.Models;

public class TestDto
{
    public string testName { get; set; } = null!;
    public string Text { get; set; } = null!;
    public ICollection<QuestionDto> Questions { get; set; } = null!;
}