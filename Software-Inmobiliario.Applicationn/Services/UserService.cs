using Software_Inmobiliario.Domain.Entities;
using Software_Inmobiliario.Domain.Interface;
using Software_Inmobiliario.Application.Interfaces;

namespace Software_Inmobiliario.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<User> CreateAsync(User user)
        {
            user.RegistrationDate = DateOnly.FromDateTime(DateTime.Now);
            await _repository.Create(user);
            await _repository.SaveChangesAsync();
            return user;
        }

        public async Task<User?> UpdateAsync(int id, User user)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return null;

            existing.Name = user.Name;
            existing.Email = user.Email;
            existing.PasswordHash = user.PasswordHash;
            existing.RoleId = user.RoleId;

            await _repository.UpdateAsync(existing);
            await _repository.SaveChangesAsync();

            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return false;

            await _repository.DeleteAsync(id);
            await _repository.SaveChangesAsync();
            return true;
        }
    }
}