using Electrimax.Products.Domain;
using MediatR.Pipeline;

namespace Electrimax.Orders.Application.Create;

public class CreateOrderCommandPreProcessor : IRequestPreProcessor<CreateOrderCommand>
{
    private readonly DbContext _context;

    public CreateOrderCommandPreProcessor(DbContext context)
    {
        _context = context;
    }

    public async Task Process(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var canCreateOrder = await CanCreateOrder(request, cancellationToken);

        if (!canCreateOrder)
        {
            throw new InvalidOperationException("Cannot create order");
        }
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
