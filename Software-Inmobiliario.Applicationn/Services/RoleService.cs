using Software_Inmobiliario.Domain.Interface;

namespace Software_Inmobiliario.Applicationn.Services;

public class RoleService
{
    private readonly IRoleRepository _repository;

    public RoleService(IRoleRepository repository)
    {
        _repository = repository;
    }
}