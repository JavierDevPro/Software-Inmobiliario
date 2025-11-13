namespace Software_Inmobiliario.Applicationn.UserDtos;

public class UserDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public DateOnly RegistrationDate { get; set; }
    public int RoleId { get; set; }
}