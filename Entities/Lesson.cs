using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeachersPet.Entities;

public class Lesson
{
    public int Id { get; set; } 
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime Date { get; set; }
    public string Subject { get; set; } = null!;
    public string Topic { get; set; } = null!;
    public string schema { get; set; } = null!;
    public ICollection<Image> Images { get; set; } = null!;
}