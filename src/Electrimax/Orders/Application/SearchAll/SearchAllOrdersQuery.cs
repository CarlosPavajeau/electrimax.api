namespace Electrimax.Orders.Application.SearchAll;

public sealed record SearchAllOrdersQuery : IRequest<IEnumerable<OrderResponse>>;
