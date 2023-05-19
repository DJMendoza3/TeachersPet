namespace TeachersPet.Models;

public class QuestionDto
{
    public string Text { get; set; } = null!;
    public ICollection<AnswerDto> Answers { get; set; } = null!;
}