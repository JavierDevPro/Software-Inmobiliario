using Microsoft.EntityFrameworkCore;
using Software_Inmobiliario.Domain.Entities;
using Software_Inmobiliario.Domain.Interfaces;
using Software_Inmobiliario.Infrastructure.Data;

public class PropertyRepository : IPropertyRepository
{
    private readonly AppDbContext _context;

    public PropertyRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Property> CreateAsync(Property property)
    {
        _context.Properties.Add(property);
        await _context.SaveChangesAsync();
        return property;
    }

    public async Task<Property> UpdateAsync(Property property)
    {
        _context.Properties.Update(property);
        await _context.SaveChangesAsync();
        return property;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var property = await _context.Properties.FindAsync(id);
        if (property == null) return false;

        _context.Properties.Remove(property);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Property>> GetAllAsync()
    {
        return await _context.Properties.Include(x => x.User).ToListAsync();
    }

    public async Task<Property> GetByIdAsync(int id)
    {
        return await _context.Properties.Include(x => x.User)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}