namespace TeachersPet.Models;

public class UserDto
{
    public string Name { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public int Credits { get; set; } = 0;

    public ICollection<TestDto> Tests { get; set; } = null!;
}