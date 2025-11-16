using Microsoft.EntityFrameworkCore;
using Software_Inmobiliario.Domain.Entities;
using Software_Inmobiliario.Domain.Interface;
using Software_Inmobiliario.Infrastructure.Data;

namespace Software_Inmobiliario.Infrastructure;

public class RoleRepository : IRoleRepository
{
    private readonly AppDbContext _dbContext;
    
    public RoleRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Role>> GetAllRolesAsync()
    {
        return await _dbContext.Roles.ToListAsync();
    }

    public async Task<Role> GetRoleByIdAsync(int roleId)
    {
        var role = await _dbContext.Roles.FirstOrDefaultAsync(r => r.Id == roleId);
        return role;
    }
    
    public async Task<string?> GetRoleNameById(int id)
    {
        var role = await Role.Roles.FirstOrDefaultAsync(r => r.Id == id);
        return role.Name;
    }
}