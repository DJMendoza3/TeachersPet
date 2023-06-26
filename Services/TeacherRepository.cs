using TeachersPet.Context;
using TeachersPet.Entities;
using Microsoft.EntityFrameworkCore;

namespace TeachersPet.Services
{
    public class TeacherRepository : ITeacherRepository 
    {
        private readonly SiteContext _context;

        public TeacherRepository(SiteContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> TeacherExists(string teachersname)
        {
            return await _context.Teachers.AnyAsync(u => u.Name == teachersname);
        }
        public async Task<bool> TeacherOwnsTest(int teachersId, int testId)
        {
            return await _context.Teachers.Where(u => u.Id == teachersId).Include(u => u.Tests).SelectMany(u => u.Tests).AnyAsync(t => t.Id == testId);
        }

        public async Task<Teacher> GetTeacher(string teachersname)
        {
            return await _context.Teachers.FirstOrDefaultAsync(u => u.Name == teachersname);
        }

        public async Task<Teacher> GetTeacher(int id)
        {
            return await _context.Teachers.FirstOrDefaultAsync(u => u.Id == id);
        }

        public Teacher CreateTeacher(Teacher teachers)
        {
            _context.Teachers.AddAsync(teachers);
            _context.SaveChangesAsync();
            return teachers;
        }

        public async Task<Teacher> UpdateTeacher(Teacher teachers)
        {
            _context.Teachers.Update(teachers);
            await _context.SaveChangesAsync();
            return teachers;
        }

        public async Task<Teacher> DeleteTeacher(Teacher teachers)
        {
            _context.Teachers.Remove(teachers);
            await _context.SaveChangesAsync();
            return teachers;
        }

        public async Task<Teacher> DeleteTeacher(int id)
        {
            var teachers = await _context.Teachers.FirstOrDefaultAsync(u => u.Id == id);
            _context.Teachers.Remove(teachers);
            await _context.SaveChangesAsync();
            return teachers;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        public async Task<int> AddCredits(int id, int credits)
        {
            var teachers = await _context.Teachers.FirstOrDefaultAsync(u => u.Id == id);
            teachers.Credits += credits;
            await _context.SaveChangesAsync();
            return teachers.Id;
        }

    }
}