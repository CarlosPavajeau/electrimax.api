namespace Electrimax.Orders.Domain;

public class Order
{
    public Order()
    {
        // EF Core
    }

    [Key] public Guid Id { get; set; }

    [MaxLength(10)] public string CustomerId { get; set; }
    [MaxLength(100)] public string CustomerAddress { get; set; }

    public DateTime CreatedAt { get; set; }

    public decimal SubTotal { get; set; }
    public decimal Total { get; set; }
    public decimal Discount { get; set; }

    public ICollection<OrderItem> Items { get; set; } = new HashSet<OrderItem>();
    
    public void CalculateTotal()
    {
        SubTotal = Items.Sum(x => x.Price * x.Quantity);
        Total = SubTotal - Discount;
    }
}
