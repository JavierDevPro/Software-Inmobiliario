using System.ComponentModel.DataAnnotations.Schema;

namespace Software_Inmobiliario.Domain.Entities;

public class Property
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string Location { get; set; }
    public string ImageUrl { get; set; }
    
    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public User User { get; set; }
    
}