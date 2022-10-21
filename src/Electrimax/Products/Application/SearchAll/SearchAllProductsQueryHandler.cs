using Mapster;

namespace Electrimax.Products.Application.SearchAll;

public class SearchAllProductsQueryHandler : IRequestHandler<SearchAllProductsQuery, IEnumerable<ProductResponse>>
{
    private readonly ProductsSearcher _searcher;

    public SearchAllProductsQueryHandler(ProductsSearcher searcher)
    {
        _searcher = searcher;
    }

    public async Task<IEnumerable<ProductResponse>> Handle(SearchAllProductsQuery request,
        CancellationToken cancellationToken)
    {
        var products = await _searcher.SearchAll();

        return products.Adapt<IEnumerable<ProductResponse>>();
    }
}
