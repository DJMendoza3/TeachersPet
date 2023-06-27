using Microsoft.EntityFrameworkCore;
using TeachersPet.Entities;
using TeachersPet.Context;

namespace TeachersPet.Services
{
    public class AuthRepository : IAuthRepository
    {
        private readonly SiteContext _context;
        private readonly IUserRepository _userRepository;
        public AuthRepository(SiteContext context, IUserRepository userRepository)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<bool> UserExists(string name)
        {

            return await _context.Users.AnyAsync(t => t.Name == name);

        }

        public async Task<User> GetUser(string name)
        {

            return await _context.Users.Where(t => t.Name == name).FirstOrDefaultAsync();

        }

        public async Task<User> GetUser(int id)
        {

            return await _context.Users.Where(t => t.Id == id).FirstOrDefaultAsync();

        }

        public async Task<User> CreateUser(User user)
        {

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

    }
}