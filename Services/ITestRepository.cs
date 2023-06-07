using TeachersPet.Entities;

namespace TeachersPet.Services
{
    public interface ITestRepository
    {
        Task<bool> TestExists(string testName);
        Task<bool> TestExists(int id);
        Task<Test> GetTest(string testName);
        Task<Test> GetTest(int id);
        Task<Test[]> GetTests(int userId);
        Task<Test> CreateTest(Test test, int userId);
        Task<bool> UpdateTest(Test test);
        Task<bool> DeleteTest(Test test, int userId);
        Task<bool> DeleteTest(int id, int userId);
    }
}
