# Electrimax

## Before you start

Your system needs to have the following installed:

- [.Net core 6.0](https://dotnet.microsoft.com/download/dotnet/6.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Ef Core Tools](https://docs.microsoft.com/en-us/ef/core/cli/dotnet)
- [Rider](https://www.jetbrains.com/rider/), [Visual Studio](https://visualstudio.microsoft.com/) (or your preferred
  IDE)

### Configuration

The appsettings.json file contains the following configuration options:

- `ConnectionStrings.Default`: The connection string to the database

### Database

The database is created using Entity Framework Core. The database is created using migrations. To create the database,
run the following command in the `src/Electrimax` directory:

```bash
 dotnet ef database update  -s ../../apps/Electrimax.Api/Electrimax.Api.csproj
```

## Running the app

To run the app, run the following command in the root directory:

```bash
 dotnet run --project apps/Electrimax.Api/Electrimax.Api.csproj
```
