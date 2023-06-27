using TeachersPet.Entities;
using Microsoft.EntityFrameworkCore;

namespace TeachersPet.Context;

public class SiteContext: DbContext
{
    public SiteContext(DbContextOptions<SiteContext> options) : base(options)
    {
    }
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<School> Schools { get; set; } = null!;
    public DbSet<Test> Tests { get; set; } = null!;
    public DbSet<Lesson> Lessons { get; set; } = null!;
    public DbSet<ActiveExam> ActiveExams { get; set; } = null!;
    public DbSet<Answer> Answers { get; set; } = null!;
    public DbSet<Course> Courses { get; set; } = null!;
}