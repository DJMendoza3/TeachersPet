using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeachersPet.Entities;

public class TestResult 
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public Test Test { get; set; } = null!;
    public Course Course { get; set; } = null!;
    public float Result { get; set; } = 0;
}