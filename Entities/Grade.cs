using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeachersPet.Entities;

public class Grade
{
    public int Id { get; set; }
    public int Value { get; set; }
    public string Comment { get; set; } = null!;
    public Test Test { get; set; } = null!;
}