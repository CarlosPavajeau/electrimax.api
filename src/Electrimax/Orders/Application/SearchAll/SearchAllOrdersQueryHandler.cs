using Mapster;

namespace Electrimax.Orders.Application.SearchAll;

public class SearchAllOrdersQueryHandler : IRequestHandler<SearchAllOrdersQuery, IEnumerable<OrderResponse>>
{
    private readonly OrdersSearcher _searcher;

    public SearchAllOrdersQueryHandler(OrdersSearcher searcher)
    {
        _searcher = searcher;
    }

    public async Task<IEnumerable<OrderResponse>> Handle(SearchAllOrdersQuery request,
        CancellationToken cancellationToken)
    {
        var orders = await _searcher.SearchAll();

        return orders.Adapt<IEnumerable<OrderResponse>>();
    }
}
