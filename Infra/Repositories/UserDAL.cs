using Domain.Users;
using Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class UserDAL : IUserDAL
    {
        private readonly AppDbContext _context;
        public UserDAL(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<User?> GetAsync(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(p => p.Email == email);
        }

        public async Task<bool> InsertAsync(User entity)
        {
            _context.Add(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<User?> Login(User user)
        {
            return await _context.Users.Where(p => p.Email == user.Email || p.PasswordHash == user.PasswordHash).FirstOrDefaultAsync();
        }

        public async Task<bool> Remove(User entity)
        {
            _context.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> UpdateAsync(User entity)
        {
            _context.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UserExists(string email, string passwordHash)
        {
            var userExists = await _context.Users.Where(p => p.Email == email
            || p.PasswordHash == passwordHash)
                .FirstOrDefaultAsync();
            if (userExists != null) return true;

            return false;
        }
    }
}
