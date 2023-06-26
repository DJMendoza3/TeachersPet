using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeachersPet.Entities;

public class Student: User
{
    public ICollection<Course> Courses { get; set; } = null!;
    public ICollection<Note> Notes { get; set; } = null!;
}