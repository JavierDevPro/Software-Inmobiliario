using System.ComponentModel.DataAnnotations.Schema;

namespace Software_Inmobiliario.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public DateOnly RegistrationDate { get; set; }
    public int RoleId { get; set; }
    [ForeignKey("RoleId")]
    public Role Role { get; set; }
        
    public List<Property> Properties = new List<Property>();
}