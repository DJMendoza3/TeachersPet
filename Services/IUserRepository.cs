using TeachersPet.Entities;

namespace TeachersPet.Services
{
    public interface IUserRepository
    {
        Task<bool> UserExists(string username);
        Task<User> GetUser(string username);
        Task<User> GetUser(int id);
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(User user);
        Task<User> DeleteUser(User user);
        Task<User> DeleteUser(int id);
    }
}