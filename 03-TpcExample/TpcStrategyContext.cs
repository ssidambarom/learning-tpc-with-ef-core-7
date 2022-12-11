using Domain;
using Microsoft.EntityFrameworkCore;

namespace _03TphExample;

public class TpcStrategyContext : PersonContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Server=localhost,1434;Database=TpcStrategy;User ID=sa;Password=Pa55w0rd!!;Encrypt=False");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>().UseTpcMappingStrategy();
        base.OnModelCreating(modelBuilder);
    }
}