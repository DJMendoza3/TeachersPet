using TeachersPet.Entities;

namespace TeachersPet.Services
{
    public interface IAuthRepository
    {
        Task<bool> UserExists(string name);
        Task<User> GetUser(string name);
        Task<User> GetUser(int id);
        Task<User> CreateUser(User user);
    }
}