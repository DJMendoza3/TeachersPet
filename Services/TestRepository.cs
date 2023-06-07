using Microsoft.EntityFrameworkCore;
using TeachersPet.Entities;
using TeachersPet.Context;

namespace TeachersPet.Services
{
    public class TestRepository : ITestRepository
    {
        private readonly SiteContext _context;
        private readonly IUserRepository _userRepository;

        public TestRepository(SiteContext context, IUserRepository userRepository)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
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
            if (testName != null && !await TestExists(testName))
            {
                throw new ArgumentNullException(nameof(testName));
            }
            //query tests including foreign key data
            return await _context.Tests.Where(t => t.TestName == testName).Include(t => t.Questions).ThenInclude(q => q.Answers).FirstOrDefaultAsync();
        }

        public async Task<Test> GetTest(int id)
        {
            return await _context.Tests.Where(t => t.Id == id).Include(t => t.Questions).ThenInclude(q => q.Answers).FirstOrDefaultAsync();
        }

        public async Task<Test[]> GetTests(int userId)
        {
            return await _context.Users.Where(u => u.Id == userId).Include(u => u.Tests).ThenInclude(t => t.Questions).ThenInclude(q => q.Answers).SelectMany(u => u.Tests).ToArrayAsync();
        }

        public async Task<Test> CreateTest(Test test, int userId)
        {
            var user = await _userRepository.GetUser(userId);
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            if (user.Tests == null)
            {
                user.Tests = new List<Test>();
            }
            user.Tests.Add(test);
            await _context.SaveChangesAsync();
            return test;
        }

        public async Task<bool> UpdateTest(Test test)
        {
            
            _context.Tests.Update(test);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTest(Test test, int userId)
        {
            var user = await _userRepository.GetUser(userId);
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            if (test == null)
            {
                throw new ArgumentNullException(nameof(test));
            }
            //if the test is not in the user's list of tests, throw an exception
            if (!user.Tests.Contains(test))
            {
                throw new ArgumentException("Test does not belong to user");
            }
            _context.Tests.Remove(test);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTest(int id, int userId)
        {
            var user = await _userRepository.GetUser(userId);
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            var test = await _context.Tests.FirstOrDefaultAsync(t => t.Id == id);
            if (test == null)
            {
                throw new ArgumentNullException(nameof(test));
            }
            //if the test is not in the user's list of tests, throw an exception
            if (!user.Tests.Contains(test))
            {
                throw new ArgumentException("Test does not belong to user");
            }
            _context.Tests.Remove(test);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}