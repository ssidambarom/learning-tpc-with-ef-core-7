using Domain;
using Microsoft.EntityFrameworkCore;

namespace _02TptExample;

public class TptStrategyContext : PersonContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Server=localhost,1434;Database=TptStrategy;User ID=sa;Password=Pa55w0rd!!;Encrypt=False");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>().UseTptMappingStrategy();
        base.OnModelCreating(modelBuilder);
    }
}