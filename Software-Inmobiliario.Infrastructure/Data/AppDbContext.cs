using Microsoft.EntityFrameworkCore;
using Software_Inmobiliario.Domain.Entities;

namespace Software_Inmobiliario.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
    DbSet<User> Users { get; set; }
    DbSet<Role> Roles { get; set; }
    DbSet<Property> Properties { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<User>()
            .HasOne(a => a.Role)
            .WithMany(u => u.Users)
            .HasForeignKey(a => a.RoleId)
            .OnDelete(DeleteBehavior.Restrict);        
        
        modelBuilder.Entity<Property>()
            .HasOne(a => a.User)
            .WithMany(p => p.Properties)
            .HasForeignKey(a => a.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
    
}