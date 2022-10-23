using Electrimax.Products.Domain;
using Electrimax.Shared.Domain.Orders;

namespace Electrimax.Products.Application.DecreaseStock;

public class DecreaseProductStockWhenOrderIsCreated : INotificationHandler<OrderCreated>
{
    private readonly DbContext _context;

    public DecreaseProductStockWhenOrderIsCreated(DbContext context)
    {
        _context = context;
    }

    public async Task Handle(OrderCreated notification, CancellationToken cancellationToken)
    {
        var productsIds = notification.ItemsCreated.Select(x => x.ProductId).ToList();
        var products = await _context.Set<Product>()
            .Where(x => productsIds.Contains(x.Id))
            .ToListAsync(cancellationToken);

        foreach (var item in notification.ItemsCreated)
        {
            var product = products.Single(x => x.Id == item.ProductId);
            product.DecreaseStock(item.Quantity);
            
            _context.Set<Product>().Update(product);
        }
        
        await _context.SaveChangesAsync(cancellationToken);
    }
}
