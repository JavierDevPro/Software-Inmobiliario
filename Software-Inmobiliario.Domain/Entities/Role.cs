namespace Software_Inmobiliario.Domain.Entities;

public class Role
{
    public int Id { get; set; }
    public string Name { get; set; }  = string.Empty;

    public List<User> Users = new List<User>();
}