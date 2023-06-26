using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeachersPet.Entities;

public class Syllabus
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string schema { get; set; } = null!;
    public string prompt { get; set; } = null!;
    public ICollection<Lesson> Lessons { get; set; } = null!;
}