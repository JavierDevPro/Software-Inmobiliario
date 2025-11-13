using Microsoft.EntityFrameworkCore;
using Software_Inmobiliario.Domain.Entities;
using Software_Inmobiliario.Domain.Interfaces;
using Software_Inmobiliario.Infrastructure.Data;

namespace Software_Inmobiliario.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly InmobiliariaContext _context;

        public UserRepository(InmobiliariaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users
                .Include(u => u.Role)
                .Include(u => u.Properties)
                .ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users
                .Include(u => u.Role)
                .Include(u => u.Properties)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
        }

        public async Task DeleteAsync(int id)
        {
            var user = await GetByIdAsync(id);
            if (user != null)
                _context.Users.Remove(user);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}