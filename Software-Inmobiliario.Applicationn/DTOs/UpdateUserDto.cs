namespace Software_Inmobiliario.Application.Dtos;

public class UpdateUserDto
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public int? RoleId { get; set; }
}