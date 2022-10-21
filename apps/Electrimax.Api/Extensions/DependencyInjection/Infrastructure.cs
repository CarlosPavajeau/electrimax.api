using Electrimax.Shared.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Helpers;

namespace Electrimax.Api.Extensions.DependencyInjection;

public static class Infrastructure
{
    public const string CorsPolicy = "AllowAll";

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ElectrimaxDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("Default"))
                .UseSnakeCaseNamingConvention()
                .EnableDetailedErrors();
        }, ServiceLifetime.Transient);

        services.AddScoped<DbContext, ElectrimaxDbContext>();

        services.AddMediatR(AssemblyHelper.GetInstance(Assemblies.Electrimax)).AddMediatR(typeof(Program).Assembly);

        services.AddRouting(route => route.LowercaseUrls = true);

        return services;
    }

    private static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(CorsPolicy, policyBuilder =>
            {
                policyBuilder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });
    }
}
