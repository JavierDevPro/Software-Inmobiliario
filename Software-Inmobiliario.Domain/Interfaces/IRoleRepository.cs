namespace Software_Inmobiliario.Domain.Interfaces;

public interface IRoleRepository
{
    Task<string?> GetRoleNameById(int id);
}