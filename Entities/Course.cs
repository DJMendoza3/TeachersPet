using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeachersPet.Entities;

public class Course 
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public ICollection<Lesson> Lessons { get; set; } = null!;
    public ICollection<Syllabus> Syllabi { get; set; } = null!;
    public ICollection<Test> Tests { get; set; } = null!;
}