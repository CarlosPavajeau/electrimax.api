using Electrimax.Products.Application;

namespace Electrimax.Orders.Application;

public sealed record OrderItemResponse(int Id, ProductResponse Product, int Quantity, decimal Price);
