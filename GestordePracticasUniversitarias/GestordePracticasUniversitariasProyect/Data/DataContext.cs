using GestordePracticasUniversitariasProyect.Models.Entites;
using Microsoft.EntityFrameworkCore;
namespace GestordePracticasUniversitariasProyect.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Company> Companies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>()
            .Property(c => c.IsActive)
            .HasDefaultValue(true);

        modelBuilder.Entity<Student>()
            .Property(s => s.IsActive)
            .HasDefaultValue(true);
    }
}