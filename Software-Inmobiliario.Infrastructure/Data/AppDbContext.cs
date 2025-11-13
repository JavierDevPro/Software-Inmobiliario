using Microsoft.EntityFrameworkCore;
using Software_Inmobiliario.Domain.Entities;

namespace Software_Inmobiliario.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Role> Roles { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<User>().HasKey(u => u.Id);
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<Role>().HasKey(r => r.Id);

        // Optional: configure DateOnly mapping for EF Core 9 (handled automatically in many providers)
    }
}