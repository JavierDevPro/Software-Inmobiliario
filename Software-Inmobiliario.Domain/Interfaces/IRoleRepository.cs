using Software_Inmobiliario.Domain.Entities;

namespace Software_Inmobiliario.Domain.Interface;

public interface IRoleRepository
{
    Task<IEnumerable<Role>> GetAllRolesAsync();
    Task<Role> GetRoleByIdAsync(int roleId);
    Task<string?> GetRoleNameById(int id);
}