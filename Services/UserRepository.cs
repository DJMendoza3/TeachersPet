using Microsoft.EntityFrameworkCore;
using TeachersPet.Entities;
using TeachersPet.Context;

namespace TeachersPet.Services
{
    public class UserRepository: IUserRepository
    {
        private readonly SiteContext _context;
        private readonly ITeacherRepository _teacherRepository;
        public UserRepository(SiteContext context, ITeacherRepository teacherRepository)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _teacherRepository = teacherRepository ?? throw new ArgumentNullException(nameof(teacherRepository));
        }

        public async Task<bool> UserExists(string name, Role role)
        {
            switch (role)
            {
                case Role.Teacher:
                    return await _context.Teachers.AnyAsync(t => t.Name == name);
                case Role.Student:
                    return await _context.Students.AnyAsync(s => s.Name == name);
                case Role.Faculty:
                    return await _context.Faculty.AnyAsync(f => f.Name == name);
                default:
                    return false;
            }
        }

        public async Task<User> GetUser(string name, Role role)
        {
            switch (role)
            {
                case Role.Teacher:
                    return await _context.Teachers.Where(t => t.Name == name).FirstOrDefaultAsync();
                case Role.Student:
                    return await _context.Students.Where(s => s.Name == name).FirstOrDefaultAsync();
                case Role.Faculty:
                    return await _context.Faculty.Where(f => f.Name == name).FirstOrDefaultAsync();
                default:
                    return null!;
            }
        }

        public async Task<User> GetUser(int id, Role role)
        {
            switch (role)
            {
                case Role.Teacher:
                    return await _context.Teachers.Where(t => t.Id == id).FirstOrDefaultAsync();
                case Role.Student:
                    return await _context.Students.Where(s => s.Id == id).FirstOrDefaultAsync();
                case Role.Faculty:
                    return await _context.Faculty.Where(f => f.Id == id).FirstOrDefaultAsync();
                default:
                    return null!;
            }
        }

        public async Task<User> CreateUser(User user, Role role)
        {
            switch (role)
            {
                case Role.Teacher:
                    _context.Teachers.Add((Teacher)user);
                    break;
                case Role.Student:
                    _context.Students.Add((Student)user);
                    break;
                case Role.Faculty:
                    _context.Faculty.Add((Faculty)user);
                    break;
                default:
                    return null!;
            }
            await _context.SaveChangesAsync();
            return user;
        }

    }
}