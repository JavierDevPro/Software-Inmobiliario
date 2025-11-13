using Software_Inmobiliario.Domain.Entities;

namespace Software_Inmobiliario.Domain.Interfaces;
public interface IUserRepository
{
    Task<User> Create(User user);
    Task<User> GetUserByEmail(string email);
    Task<IEnumerable<User>> GetAllAsync();
    Task<User?> GetByIdAsync(int id);
    Task UpdateAsync(User user);
    Task DeleteAsync(int id);
    Task SaveChangesAsync();
}