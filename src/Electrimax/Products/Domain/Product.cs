using System.ComponentModel.DataAnnotations.Schema;
using Electrimax.SalesDepartments.Domain;

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

    [Precision(10, 3)] public decimal Price { get; set; }

    public DateTime CreatedAt { get; set; }

    [ForeignKey(nameof(SalesDepartmentId))]
    public SalesDepartment SalesDepartment { get; set; }

    public int SalesDepartmentId { get; set; }

    public static Product Create(string name, string color, int quantity, decimal price, int salesDepartmentId)
    {
        return new Product
        {
            Id = Guid.NewGuid(),
            Name = name,
            Color = color,
            Quantity = quantity,
            Price = price,
            SalesDepartmentId = salesDepartmentId,
            CreatedAt = DateTime.UtcNow
        };
    }
}
