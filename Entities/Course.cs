using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeachersPet.Entities;

public class Course 
{
    public ICollection<Student> Students { get; set; } = null!;
    public ICollection<Teacher> Teachers { get; set; } = null!;
    public ICollection<Test> Tests { get; set; } = null!;
}