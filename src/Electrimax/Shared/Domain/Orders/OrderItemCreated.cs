namespace Electrimax.Shared.Domain.Orders;

public record OrderItemCreated(Guid ProductId, int Quantity);
