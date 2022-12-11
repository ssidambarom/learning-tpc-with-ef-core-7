#r "nuget: System.Data.SqlClient, 4.8.3"
#r "nuget: Dapper, 2.0.123"

open System.Data.SqlClient
open Dapper
open System.Threading.Tasks
open System

printfn $"Running %s{__SOURCE_FILE__}"

let dbConnectionString =
    "Server=localhost,1434;Database=master;User ID=sa;Password=Sc63ym23!!;"

let dbName = "My_Db_Name_Here"
let doesDbExistsQuery = $"IF DB_ID('%s{dbName}') IS NOT NULL SELECT 1 ELSE SELECT 0"
let dbCreationCmd = $"CREATE DATABASE %s{dbName}"
let con = new SqlConnection(dbConnectionString)

let mutable executionError = 0

try
    try
        printfn "Waiting 90s for SQL Server to be ready for sure..."
        Task.Delay(TimeSpan.FromSeconds(90)) |> Async.AwaitTask |> Async.RunSynchronously |> ignore

        printfn "Connection to the database..."
        con.Open()


        printfn "Check if database exists..."

        let dbExists =
            con.QuerySingleAsync<int>(doesDbExistsQuery)
            |> Async.AwaitTask
            |> Async.RunSynchronously

        if dbExists = 1 then
            printfn $"%s{dbName} already exists"
        else
            printfn $"Create database %s{dbName}..."
            con.Execute(dbCreationCmd) |> ignore
    with
    | ex ->
        executionError <- 1
        printfn $"%s{__SOURCE_FILE__} failure !"
        printfn $"%A{exn}"
finally
    con.Close()

printfn "Done !"
executionError
//TODO: Set up containers with needed excel template files.
