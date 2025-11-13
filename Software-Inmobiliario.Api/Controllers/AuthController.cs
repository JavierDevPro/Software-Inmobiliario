using Microsoft.AspNetCore.Mvc;
using Software_Inmobiliario.Applicationn.Authentication;
using Software_Inmobiliario.Applicationn.Interfaces;

namespace Software_Inmobiliario.Api.Controller;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _service;

    public AuthController(IAuthService service)
    {
        _service = service;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] AuthRegisterDto entity)
    {
        var result = await _service.Register(entity);
        return (result == null) ? BadRequest(new { message = "Registro denegado" }) : Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] AuthLoginDto entity)
    {
        var result = await _service.Login(entity);
        return (result == null) ? BadRequest(new { message = "Login denegado" }) : Ok(result);
    }
}