using Electrimax.Products.Application.Create;
using Electrimax.Products.Application.SearchAll;
using MediatR;

namespace Electrimax.Api.Endpoints;

public static class Products
{
    public static void MapProductsEndpoints(this WebApplication app)
    {
        app.MapGet("/products", GetProducts);
        app.MapPost("/products", CreateProduct);
    }

    private static async Task<IResult> GetProducts(IMediator mediator)
    {
        var result = await mediator.Send(new SearchAllProductsQuery());

        return Results.Ok(result);
    }

    private static async Task<IResult> CreateProduct(IMediator mediator, [FromBody] CreateProductCommand command)
    {
        var result = await mediator.Send(command);

        return Results.Ok(result);
    }
}
