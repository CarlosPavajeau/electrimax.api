using Electrimax.Orders.Application.Create;
using Electrimax.Orders.Application.SearchAll;
using MediatR;

namespace Electrimax.Api.Endpoints;

public static class Orders
{
    public static void MapOrdersEndpoints(this WebApplication app)
    {
        app.MapGet("/orders", GetOrders);
        app.MapPost("/orders", CreateOrder);
    }

    private static async Task<IResult> GetOrders(IMediator mediator)
    {
        var orders = await mediator.Send(new SearchAllOrdersQuery());

        return Results.Ok(orders);
    }

    private static async Task<IResult> CreateOrder(IMediator mediator, [FromBody] CreateOrderCommand command)
    {
        var order = await mediator.Send(command);

        return Results.Ok(order);
    }
}
