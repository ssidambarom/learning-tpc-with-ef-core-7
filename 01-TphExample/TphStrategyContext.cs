using Domain;
using Microsoft.EntityFrameworkCore;
namespace _01TphExample;

public class TphStrategyContext : PersonContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Server=localhost,1434;Database=TphStrategy;User ID=sa;Password=Pa55w0rd!!;Encrypt=False");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>().UseTphMappingStrategy();
        base.OnModelCreating(modelBuilder);
    }
}