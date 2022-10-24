namespace Electrimax.Orders.Application.Create;

public sealed record CreateOrderItemCommand(Guid ProductId, int Quantity, decimal Price);
