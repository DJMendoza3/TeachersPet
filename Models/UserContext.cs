using Microsoft.EntityFrameworkCore;

namespace TeachersPet.Models;

public class UserContext: DbContext
{
    public UserContext(DbContextOptions<UserContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;
}