namespace Electrimax.Shared.Domain.Orders;

public record OrderCreated(Guid OrderId, IEnumerable<OrderItemCreated> ItemsCreated) : INotification;
