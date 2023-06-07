using TeachersPet.Context;
using TeachersPet.Entities;
using Microsoft.EntityFrameworkCore;

namespace TeachersPet.Services
{
    public class UserRepository : IUserRepository 
    {
        private readonly SiteContext _context;

        public UserRepository(SiteContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(u => u.UserName == username);
        }
        public async Task<bool> UserOwnsTest(int userId, int testId)
        {
            return await _context.Users.Where(u => u.Id == userId).Include(u => u.Tests).SelectMany(u => u.Tests).AnyAsync(t => t.Id == testId);
        }

        public async Task<User> GetUser(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
        }

        public async Task<User> GetUser(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public User CreateUser(User user)
        {
            _context.Users.AddAsync(user);
            _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUser(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> DeleteUser(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> DeleteUser(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        public async Task<User> CreateUser()
        {
            throw new NotImplementedException();
        }

        Task<User> IUserRepository.CreateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}