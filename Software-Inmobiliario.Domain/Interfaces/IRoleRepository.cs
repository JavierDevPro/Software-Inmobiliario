namespace Software_Inmobiliario.Domain.Interface;

public interface IRoleRepository
{
    Task<string?> GetRoleNameById(int id);
}