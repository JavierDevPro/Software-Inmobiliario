using Microsoft.EntityFrameworkCore;
using Software_Inmobiliario.Domain.Interface;
using Software_Inmobiliario.Infrastructure.Data;

namespace Software_Inmobiliario.Infrastructure;

public class RoleRepository : IRoleRepository
{
    private readonly AppDbContext _context;

    public RoleRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<string?> GetRoleNameById(int id)
    {
        var role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == id);
        return role.Name;
    }
}
