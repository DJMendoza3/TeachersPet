using TeachersPet.Entities;

namespace TeachersPet.Services
{

    public enum UserTypes
    {
        Teacher,
        Student,
        Faculty
    }
    public interface IUserRepository
    {
        Task<bool> UserExists(string name, UserTypes userType);
        Task<User> GetUser(string name, UserTypes userType);
        Task<User> GetUser(int id, UserTypes userType);
        Task<User> CreateUser(User user, UserTypes userType);
    }
}