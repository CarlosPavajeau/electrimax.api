namespace Electrimax.Products.Domain;

public class Product
{
    public Product()
    {
        // EF Core
    }

    [Key] public Guid Id { get; set; }

    [MaxLength(70)] public string Name { get; set; }
    [MaxLength(30)] public string Color { get; set; }

    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public DateTime CreatedAt { get; set; }

    public static Product Create(string name, string color, int quantity, decimal price)
    {
        return new Product
        {
            Id = Guid.NewGuid(),
            Name = name,
            Color = color,
            Quantity = quantity,
            Price = price,
            CreatedAt = DateTime.UtcNow
        };
    }
}
