using System.ComponentModel.DataAnnotations.Schema;
using Electrimax.Products.Domain;

namespace Electrimax.Orders.Domain;

public class OrderItem
{
    public OrderItem()
    {
        // EF Core
    }

    [Key] public int Id { get; set; }

    [ForeignKey(nameof(OrderId))] public Order Order { get; set; }
    public Guid OrderId { get; set; }

    [ForeignKey(nameof(ProductId))] public Product Product { get; set; }
    public Guid ProductId { get; set; }

    public int Quantity { get; set; }
    [Precision(10, 3)] public decimal Price { get; set; }
}
