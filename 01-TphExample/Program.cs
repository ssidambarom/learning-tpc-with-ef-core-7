using _01TphExample;
using Domain;

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
        Console.WriteLine("Run Tph strateg ...");

        await DbContextExentions.Seed<TphStrategyContext>();

        await DbContextExentions.ReadAllDb<TphStrategyContext>();
    }
}
