using Electrimax.Orders.Domain;

namespace Electrimax.Test.Orders.Domain;

public static class OrderMother
{
    public static Order Random()
    {
        var faker = new Faker();

        var order = new Order
        {
            Id = Guid.NewGuid(),
            CustomerAddress = faker.Address.ToString()!,
            CustomerId = faker.Random.Word(),
            CreatedAt = DateTime.UtcNow,

            Items = new HashSet<OrderItem>
            {
                new()
                {
                    ProductId = Guid.NewGuid(),
                    Quantity = faker.Random.Int(1, 10),
                    Price = faker.Random.Decimal(1, 100)
                }
            }
        };

        order.CalculateTotal();

        return order;
    }
}
