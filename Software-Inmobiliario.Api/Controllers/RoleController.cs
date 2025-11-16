using Microsoft.AspNetCore.Mvc;
using Software_Inmobiliario.Applicationn.Interfaces;

namespace Software_Inmobiliario.Api.Controller;

[ApiController]
[Route("api/[controller]")]
public class RoleController : ControllerBase
{
    private readonly IRoleService _service;

    public RoleController(IRoleService service)
    {
        _service = service;
    }

    [HttpGet("getall")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllRolesAsync();
        return result != null ? Ok(result) : BadRequest(new { message = "ERROR: There are not any role registered."});
    }
}