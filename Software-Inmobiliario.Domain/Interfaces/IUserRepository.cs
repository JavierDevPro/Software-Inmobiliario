using Software_Inmobiliario.Domain.Entities;

namespace Software_Inmobiliario.Domain.Interface;

public interface IUserRepository
{
    Task<User> Create(User user);
    
    Task<User> GetUserByEmail(string email);
}