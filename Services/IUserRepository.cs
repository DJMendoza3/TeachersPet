using TeachersPet.Entities;

namespace TeachersPet.Services
{
    public interface IUserRepository
    {
        Task<bool> UserExists(string name, Role role);
        Task<User> GetUser(string name, Role role);
        Task<User> GetUser(int id, Role role);
        Task<User> CreateUser(User user, Role role);
    }
}