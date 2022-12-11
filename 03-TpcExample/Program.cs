using Domain;
using _03TphExample;

internal class Program
{
    /*
    dotnet --list-sdks 

    dotnet new console -n 03-TpcExample
    dotnet sln add .\03-TpcExample\  
    dotnet add reference ..\Domain\Domain.csproj 

    dotnet add package Microsoft.EntityFrameworkCore.Design 

    /!\ dotnet tool update --global dotnet-ef

    dotnet ef dbcontext list

    dotnet ef migrations add InitialCreate -c TpcStrategyContext 
    
    dotnet ef migrations script -i -o Migrations.sql
    */
    private static async Task Main(string[] args)
    {
        Console.WriteLine("Run Tpc strateg ...");

        await DbContextExentions.Seed<TpcStrategyContext>();

        await DbContextExentions.ReadAllDb<TpcStrategyContext>();
    }
}
