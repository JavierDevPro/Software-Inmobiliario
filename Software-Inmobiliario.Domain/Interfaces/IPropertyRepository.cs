using Software_Inmobiliario.Domain.Entities;

namespace Software_Inmobiliario.Domain.Interfaces;

public interface IPropertyRepository
{
    Task<Property> CreateAsync(Property property);
    Task<Property> UpdateAsync(Property property);
    Task<bool> DeleteAsync(int id);
    Task<IEnumerable<Property>> GetAllAsync();
    Task<Property> GetByIdAsync(int id);
}