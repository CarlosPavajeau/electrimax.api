namespace Electrimax.Orders.Application.Create;

public sealed record CreateOrderCommand(
    string CustomerId,
    string CustomerAddress,
    IEnumerable<CreateOrderItemCommand> Items
) : IRequest<Guid>;
