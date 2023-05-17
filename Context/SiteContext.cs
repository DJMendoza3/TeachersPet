using TeachersPet.Entities;
using Microsoft.EntityFrameworkCore;

namespace TeachersPet.Context;

public class SiteContext: DbContext
{
    public SiteContext(DbContextOptions<SiteContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;

    public DbSet<Test> Tests { get; set; } = null!;
}