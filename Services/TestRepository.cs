using Microsoft.EntityFrameworkCore;
using TeachersPet.Entities;
using TeachersPet.Context;

namespace TeachersPet.Services
{
    public class TestRepository : ITestRepository
    {
        private readonly SiteContext _context;

        public TestRepository(SiteContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> TestExists(string testName)
        {
            return await _context.Tests.AnyAsync(t => t.TestName == testName);
        }
        public async Task<bool> TestExists(int id)
        {
            return await _context.Tests.AnyAsync(t => t.Id == id);
        }

        public async Task<Test> GetTest(string testName)
        {
            return await _context.Tests.FirstOrDefaultAsync(t => t.TestName == testName);
        }

        public async Task<Test> GetTest(int id)
        {
            return await _context.Tests.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Test[]> GetTests(User user)
        {
            return await _context.Tests.ToArrayAsync();
        }

        public async Task<Test> CreateTest(Test test)
        {
            _context.Tests.AddAsync(test);
            await _context.SaveChangesAsync();
            return test;
        }

        public async Task<Test> UpdateTest(Test test)
        {
            _context.Tests.Update(test);
            await _context.SaveChangesAsync();
            return test;
        }

        public async Task<Test> DeleteTest(Test test)
        {
            _context.Tests.Remove(test);
            await _context.SaveChangesAsync();
            return test;
        }

        public async Task<Test> DeleteTest(int id)
        {
            var test = await _context.Tests.FirstOrDefaultAsync(t => t.Id == id);
            _context.Tests.Remove(test);
            await _context.SaveChangesAsync();
            return test;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}