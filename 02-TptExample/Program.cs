using Domain;
using _02TptExample;

internal class Program
{
    /*
    dotnet --list-sdks 

    dotnet new console -n 02-TptExample
    dotnet sln add .\02-TptExample\  
    dotnet add reference ..\Domain\Domain.csproj 

    dotnet add package Microsoft.EntityFrameworkCore.Design 

    /!\ dotnet tool update --global dotnet-ef

    dotnet ef dbcontext list

    dotnet ef migrations add InitialCreate -c TptStrategyContext 
    
    dotnet ef migrations script -i -o Migrations.sql
    */
    private static async Task Main(string[] args)
    {
        Console.WriteLine("Run Tpc strateg ...");

        await DbContextExentions.Seed<TptStrategyContext>();

        await DbContextExentions.ReadAllDb<TptStrategyContext>();
    }
}
