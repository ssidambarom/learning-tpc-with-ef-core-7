using Domain;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    /*
    dotnet --list-sdks 

    dotnet new console -n 01-TphExample
    dotnet sln add .\01-TphExample\  
    dotnet add reference ..\Domain\Domain.csproj 

    dotnet add package Microsoft.EntityFrameworkCore.Design 

    /!\ dotnet tool update --global dotnet-ef

    dotnet ef dbcontext list

    dotnet ef migrations add InitialCreate -c TphStrategyContext 
    
    dotnet ef migrations script -i -o Migrations.sql
    */
    private static async Task Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        await DbContextExentions.Seed<TphStrategyContext>();

        await DbContextExentions.ReadAllDb<TphStrategyContext>();
    }
}


public class TphStrategyContext : PersonContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1434;Database=TphStrategy;User ID=sa;Password=Pa$$w0rd;");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>().UseTphMappingStrategy();
        base.OnModelCreating(modelBuilder);
    }
}