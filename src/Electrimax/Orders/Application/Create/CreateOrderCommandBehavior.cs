using Electrimax.Products.Domain;

namespace Electrimax.Orders.Application.Create;

public class CreateOrderCommandBehavior : IPipelineBehavior<CreateOrderCommand, Guid>
{
    private readonly DbContext _context;

    public CreateOrderCommandBehavior(DbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateOrderCommand request, RequestHandlerDelegate<Guid> next,
        CancellationToken cancellationToken)
    {
        var canCreateOrder = await CanCreateOrder(request, cancellationToken);

        if (!canCreateOrder)
        {
            throw new InvalidOperationException("Cannot create order");
        }

        return await next();
    }

    private async Task<bool> CanCreateOrder(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var productIds = request.Items.Select(x => x.ProductId).ToList();
        var products = await _context.Set<Product>()
            .Where(x => productIds.Contains(x.Id))
            .ToListAsync(cancellationToken);

        foreach (var product in products)
        {
            var item = request.Items.FirstOrDefault(x => x.ProductId == product.Id);
            if (item == null)
            {
                return false;
            }

            // there must always be a product in stock
            if (item.Quantity - 1 > product.Quantity)
            {
                return false;
            }
        }

        return true;
    }
}
