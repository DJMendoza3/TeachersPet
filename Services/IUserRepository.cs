using TeachersPet.Entities;

namespace TeachersPet.Services
{
    public interface IUserRepository
    {
        Task<bool> UserExists(string username);
        Task<bool> UserOwnsTest(int userId, int testId);
        Task<User> GetUser(string username);
        Task<User> GetUser(int id);
        User CreateUser(User user);
        Task<User> UpdateUser(User user);
        Task<User> DeleteUser(User user);
        Task<User> DeleteUser(int id);
        Task<int> AddCredits(int id, int credits);
    }
}