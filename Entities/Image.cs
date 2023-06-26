using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeachersPet.Entities;

public class Image 
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string alt { get; set; } = null!;
    public string url { get; set; } = null!;
    public string prompt { get; set; } = null!;
}