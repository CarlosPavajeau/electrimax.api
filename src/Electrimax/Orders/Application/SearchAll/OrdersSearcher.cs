using Electrimax.Orders.Domain;

namespace Electrimax.Orders.Application.SearchAll;

public class OrdersSearcher
{
    private readonly DbContext _dbContext;

    public OrdersSearcher(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Order>> SearchAll()
    {
        return await _dbContext.Set<Order>()
            .Include(x => x.Items)
            .ThenInclude(x => x.Product)
            .ToListAsync();
    }
}
