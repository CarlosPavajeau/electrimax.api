namespace Electrimax.Products.Application.Create;

public record CreateProductCommand(string Name, string Color, int Quantity, decimal Price) : IRequest<Guid>;
