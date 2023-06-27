using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeachersPet.Entities;

public class Student: User
{
    public ICollection<Course> Courses { get; set; } = null!;
    public ICollection<Note> Notes { get; set; } = null!;
    public ICollection<TestResult> TestResults { get; set; } = null!;
    public ICollection<ActiveExam> ActiveExams { get; set; } = null!;
    public ICollection<Grade> Grades { get; set; } = null!;
}