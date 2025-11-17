using Software_Inmobiliario.Applicationn.DTOs.PropertyDtos;

namespace Software_Inmobiliario.Applicationn.Interfaces;

public interface IPropertyService
{
    Task<PropertyDto> CreateAsync(CreatePropertyDto dto);
    Task<PropertyDto> UpdateAsync(int id, UpdatePropertyDto dto);
    Task<bool> DeleteAsync(int id);
    Task<IEnumerable<PropertyDto>> GetAllAsync();
    Task<PropertyDto> GetByIdAsync(int id);
}