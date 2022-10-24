using Electrimax.Products.Domain;

namespace Electrimax.Products.Application.SearchAll;

public class ProductsSearcher
{
    private readonly DbContext _dbContext;

    public ProductsSearcher(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Product>> SearchAll()
    {
        return await _dbContext.Set<Product>().ToListAsync();
    }
}
