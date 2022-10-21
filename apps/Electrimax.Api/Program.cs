using Electrimax.Api.Endpoints;
using Electrimax.Api.Extensions.DependencyInjection;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add Serilog
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();
builder.Host.UseSerilog();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(Infrastructure.CorsPolicy);

app.UseAuthorization();

app.MapControllers();

app.MapSalesDepartmentEndpoints();
app.MapProductsEndpoints();
app.MapOrdersEndpoints();

app.Run();

#pragma warning disable CA1050 // Declare types in namespaces
namespace Electrimax.Api
{
    public class Program
    {
        // Only used for testing
    }
}
#pragma warning restore CA1050 // Declare types in namespaces
