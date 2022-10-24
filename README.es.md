# Electrimax

## Antes de empezar

Su sistema necesita tener instalado lo siguiente:

- [.Net core 6.0](https://dotnet.microsoft.com/download/dotnet/6.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Ef Core Tools](https://docs.microsoft.com/en-us/ef/core/cli/dotnet)
- [Rider](https://www.jetbrains.com/rider/), [Visual Studio](https://visualstudio.microsoft.com/) (o su
  IDE)

### Configuración

El archivo appsettings.json contiene las siguientes opciones de configuración:

- `ConnectionStrings.Default`: La cadena de conexión a la base de datos

### Base de datos

La base de datos se crea utilizando Entity Framework Core. La base de datos se crea utilizando migraciones. Para crear la base de datos
ejecuta el siguiente comando en el directorio `src/Electrimax`:

```bash
dotnet ef database update -s ../../apps/Electrimax.Api/Electrimax.Api.csproj
```

## Ejecutar la aplicación

Para ejecutar la aplicación, ejecuta el siguiente comando en el directorio raíz:

```bash
 dotnet run --project apps/Electrimax.Api/Electrimax.Api.csproj
```
