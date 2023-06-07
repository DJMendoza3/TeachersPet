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
        Task<Test> UpdateTest(Test test);
        Task<Test> DeleteTest(Test test);
        Task<Test> DeleteTest(int id);
    }
}
