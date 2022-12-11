

mkdir TpcWithEFCore7
cd ./TpcWithEFCore7
dotnet new sln -n TpcWithEFCore7
dotnet new classlib -n Domain
dotnet sln add .\Domain\

cd ./Domain
dotnet install Microsoft.EntityFrameworkCore
dotnet install Microsoft.EntityFrameworkCore.SqlServer

mkdir TpcWithEFCore7