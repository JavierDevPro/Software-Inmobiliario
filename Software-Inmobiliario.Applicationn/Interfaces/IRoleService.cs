using Software_Inmobiliario.Domain.Entities;

namespace Software_Inmobiliario.Applicationn.Interfaces;

public interface IRoleService
{
    Task<IEnumerable<RoleDto>> GetAllRolesAsync();
    Task<RoleDto> GetRoleByIdAsync(int roleId);
    
}