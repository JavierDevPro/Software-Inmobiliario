using Microsoft.AspNetCore.Http;

namespace Software_Inmobiliario.Applicationn.DTOs.PropertyDtos;

public class UpdatePropertyDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string Location { get; set; }
    public IFormFile? Image { get; set; }
}