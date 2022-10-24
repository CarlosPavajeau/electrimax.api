namespace Electrimax.Products.Application.SearchAll;

public sealed record SearchAllProductsQuery : IRequest<IEnumerable<ProductResponse>>;
