using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Software_Inmobiliario.Applicationn.Authentication;
using Software_Inmobiliario.Applicationn.Interfaces;
using Software_Inmobiliario.Applicationn.UserDtos;
using Software_Inmobiliario.Domain.Entities;
using Software_Inmobiliario.Domain.Interfaces;

namespace Software_Inmobiliario.Applicationn.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;
    private readonly IRoleRepository _roleRepository;
    private readonly IMapper _mapper;

    public AuthService(IUserRepository userRepository, IConfiguration configuration, IMapper mapper)
    {
        _userRepository = userRepository;
        _configuration = configuration;
        _mapper = mapper;
    }
    
    public async Task<AuthResponseDto> Register(AuthRegisterDto authRegisterDto)
    {
        var entity = await _userRepository.GetUserByEmail(authRegisterDto.Email);
        if (entity != null) return null;

        var user = _mapper.Map<User>(authRegisterDto);
        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(authRegisterDto.Password);
        user.RegistrationDate = DateOnly.FromDateTime(DateTime.Now);

        var registered = await _userRepository.Create(user);

        var response = _mapper.Map<AuthResponseDto>(registered);
        response.ExpiresAt = DateTime.Now.AddMinutes(15);
        response.Role = await _roleRepository.GetRoleNameById(registered.RoleId);

        return response;
    }

    public async Task<AuthResponseDto> Login(AuthLoginDto authLoginDto)
    {
        var user = await _userRepository.GetUserByEmail(authLoginDto.Password);
        bool isPassValid = BCrypt.Net.BCrypt.Verify(authLoginDto.Password, user.PasswordHash);

        if (!isPassValid) return null;
        var dto = _mapper.Map<UserDto>(user);
        var token = await GenerateJwtToken(dto);

        return new AuthResponseDto
        {
            Token = token,
            Email = dto.Email,
            ExpiresAt = DateTime.UtcNow.AddMinutes(15),
            Role = await _roleRepository.GetRoleNameById(dto.RoleId)
        };
    }

    public Task<AuthResponseDto> RefreshToken(string refreshToken)
    {
        throw new NotImplementedException();
    }

    private async Task<string> GenerateJwtToken(UserDto dto)
    {
        var user = _userRepository.GetUserByEmail(dto.Email);
        var claims = new[]
        {
            new Claim(ClaimTypes.Email, dto.Email),
            new Claim(ClaimTypes.Role, await _roleRepository.GetRoleNameById(dto.RoleId)),
            new Claim(ClaimTypes.NameIdentifier, dto.Id.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(15),
            signingCredentials:credentials
            
        );
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}