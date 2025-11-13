using Software_Inmobiliario.Applicationn.Interfaces;
using Software_Inmobiliario.Domain.Entities;
using Software_Inmobiliario.Domain.Interface;

namespace Software_Inmobiliario.Applicationn.Services;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;
    
    public RoleService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    private RoleDto MapDto(Role role)
    {
        return new RoleDto
        {
            Id = role.Id,
            Name = role.Name
        };
    }
    
    public Task<IEnumerable<RoleDto>> GetAllRolesAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<RoleDto> GetRoleByIdAsync(int roleId)
    {
        var role = await _roleRepository.GetRoleByIdAsync(roleId);
        return MapDto(role);
    }
}