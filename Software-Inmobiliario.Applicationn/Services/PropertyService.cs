using AutoMapper;
using Software_Inmobiliario.Applicationn.DTOs.PropertyDtos;
using Software_Inmobiliario.Applicationn.Interfaces;
using Software_Inmobiliario.Domain.Entities;
using Software_Inmobiliario.Domain.Interfaces;

public class PropertyService : IPropertyService
{
    private readonly IPropertyRepository _repo;
    private readonly ICloudinaryService _cloud;
    private readonly IMapper _mapper;

    public PropertyService(IPropertyRepository repo, ICloudinaryService cloud, IMapper mapper)
    {
        _repo = repo;
        _cloud = cloud;
        _mapper = mapper;
    }

    public async Task<PropertyDto> CreateAsync(CreatePropertyDto dto)
    {
        var imageUrl = await _cloud.UploadImageAsync(dto.Image);

        var property = new Property
        {
            Title = dto.Title,
            Description = dto.Description,
            Price = dto.Price,
            Location = dto.Location,
            UserId = dto.UserId,
            ImageUrl = imageUrl
        };

        await _repo.CreateAsync(property);

        return _mapper.Map<PropertyDto>(property);
    }

    public async Task<PropertyDto> UpdateAsync(int id, UpdatePropertyDto dto)
    {
        var property = await _repo.GetByIdAsync(id);
        if (property == null) return null;

        property.Title = dto.Title;
        property.Description = dto.Description;
        property.Price = dto.Price;
        property.Location = dto.Location;

        if (dto.Image != null)
            property.ImageUrl = await _cloud.UploadImageAsync(dto.Image);

        await _repo.UpdateAsync(property);

        return _mapper.Map<PropertyDto>(property);
    }

    public async Task<bool> DeleteAsync(int id) => await _repo.DeleteAsync(id);
    public async Task<IEnumerable<PropertyDto>> GetAllAsync() => _mapper.Map<IEnumerable<PropertyDto>>(await _repo.GetAllAsync());
    public async Task<PropertyDto> GetByIdAsync(int id) => _mapper.Map<PropertyDto>(await _repo.GetByIdAsync(id));
}