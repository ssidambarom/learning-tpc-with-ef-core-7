using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Domain;
/*

    dotnet install Microsoft.EntityFrameworkCore

*/
public class PersonContext : DbContext
{
    private const string EmployeeIdSequenceName = "EmployeeIdSequence";

    public DbSet<Person> Persons => Set<Person>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Technician> Technicians => Set<Technician>();
    public DbSet<BusinessManager> Managers => Set<BusinessManager>();


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .EnableSensitiveDataLogging();

        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>();

        modelBuilder.HasSequence<int>(EmployeeIdSequenceName);

        modelBuilder.Entity<Employee>()
            .Property(emp => emp.EmployeeId)
            .HasDefaultValueSql($"NEXT VALUE FOR {EmployeeIdSequenceName}");

        modelBuilder.Entity<Customer>();
        modelBuilder.Entity<Technician>();
        modelBuilder.Entity<BusinessManager>();

        modelBuilder.Entity<BusinessManager>()
            .HasMany(e => e.Portfolio)
            .WithMany(e => e.Contacts)
            .UsingEntity<Dictionary<object, string>>(
                "CustomersBusinessManagers",
                r => r.HasOne<Customer>().WithMany().OnDelete(DeleteBehavior.ClientCascade),
                l => l.HasOne<BusinessManager>().WithMany().OnDelete(DeleteBehavior.Cascade));

    }
}


public class TptStrategyPersonContext : PersonContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1434;Database=TptStrategy;User ID=sa;Password=Pa$$w0rd;");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>().UseTptMappingStrategy();
        base.OnModelCreating(modelBuilder);
    }
}

public class TpcStrategyPersonContext : PersonContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1434;Database=TpcStrategy;User ID=sa;Password=Pa$$w0rd;");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>().UseTpcMappingStrategy();
        base.OnModelCreating(modelBuilder);
    }
}
