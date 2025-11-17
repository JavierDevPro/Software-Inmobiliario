namespace Software_Inmobiliario.Application.Dtos;

public record UserDto(int Id, string Name, string Email, int RoleId, DateOnly RegistrationDate);