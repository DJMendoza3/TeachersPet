using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeachersPet.Entities;

public class Note 
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string prompt { get; set; } = null!;
    public string content { get; set; } = null!;
}