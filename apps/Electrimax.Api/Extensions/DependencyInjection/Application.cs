using Electrimax.Orders.Application.Create;
using Electrimax.Orders.Application.SearchAll;
using Electrimax.Products.Application.Create;
using Electrimax.Products.Application.SearchAll;
using Electrimax.SalesDepartments.Application.Create;
using Electrimax.SalesDepartments.Application.SearchAll;

namespace Electrimax.Api.Extensions.DependencyInjection;

public static class Application
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<SalesDepartmentCreator>();
        services.AddScoped<SalesDepartmentSearcher>();

        services.AddScoped<ProductCreator>();
        services.AddScoped<ProductsSearcher>();

        services.AddScoped<OrderCreator>();
        services.AddScoped<OrdersSearcher>();

        return services;
    }
}
