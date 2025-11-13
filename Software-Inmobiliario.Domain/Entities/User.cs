using System.ComponentModel.DataAnnotations.Schema;

namespace Software_Inmobiliario.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public DateOnly RegistrationDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);

    public int RoleId { get; set; }
    [ForeignKey("RoleId")]
    public Role? Role { get; set; }

    public List<Property>? Properties { get; set; } = new();
}