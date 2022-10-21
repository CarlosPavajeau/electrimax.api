using Electrimax.SalesDepartments.Application.Create;
using Electrimax.SalesDepartments.Application.SearchAll;
using MediatR;

namespace Electrimax.Api.Endpoints;

public static class SalesDepartments
{
    public static void MapSalesDepartmentEndpoints(this WebApplication app)
    {
        app.MapGet("/sales-departments", GetSalesDepartments);
        app.MapPost("/sales-departments", CreateSalesDepartment);
    }

    private static async Task<IResult> GetSalesDepartments(IMediator mediator)
    {
        var result = await mediator.Send(new SearchAllSalesDepartmentsQuery());

        return Results.Ok(result);
    }

    private static async Task<IResult> CreateSalesDepartment(IMediator mediator,
        [FromBody] CreateSalesDepartmentCommand command)
    {
        var result = await mediator.Send(command);

        return Results.Ok(result);
    }
}
