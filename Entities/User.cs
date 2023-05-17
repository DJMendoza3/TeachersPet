namespace TeachersPet.Entities;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;

    public List<Test> Tests { get; set; } = null!;
}