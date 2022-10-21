namespace Electrimax.Products.Application;

public record ProductResponse(Guid Id, string Name, string Color, int Quantity, decimal Price, DateTime CreatedAt);
