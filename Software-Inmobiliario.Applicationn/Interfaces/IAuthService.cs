using Software_Inmobiliario.Applicationn.Authentication;
using Software_Inmobiliario.Applicationn.UserDtos;


namespace Software_Inmobiliario.Applicationn.Interfaces;

public interface IAuthService
{
    Task<AuthResponseDto> Register(AuthRegisterDto authRegisterDto);

    Task<AuthResponseDto> Login(AuthLoginDto authLoginDto);
    
    Task<AuthResponseDto> RefreshToken(string refreshToken);
}