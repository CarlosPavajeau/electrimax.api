using Electrimax.Orders.Domain;

namespace Electrimax.Orders.Application.Create;

public class OrderCreator
{
    private readonly DbContext _dbContext;

    public OrderCreator(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Create(CreateOrderCommand command)
    {
        var order = new Order
        {
            Id = Guid.NewGuid(),
            CustomerId = command.CustomerId,
            CustomerAddress = command.CustomerAddress,
            CreatedAt = DateTime.UtcNow,
            Items = command.Items.Select(x => new OrderItem
            {
                ProductId = x.ProductId,
                Quantity = x.Quantity,
                Price = x.Price
            }).ToHashSet()
        };
        
        order.CalculateTotal();

        await _dbContext.AddAsync(order);
        await _dbContext.SaveChangesAsync();
        
        return order.Id;
    }
}
