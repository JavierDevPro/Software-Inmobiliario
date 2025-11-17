namespace Software_Inmobiliario.Applicationn.DTOs.PropertyDtos;

public class PropertyDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string Location { get; set; }
    public string ImageUrl { get; set; }
    public int UserId { get; set; }
}