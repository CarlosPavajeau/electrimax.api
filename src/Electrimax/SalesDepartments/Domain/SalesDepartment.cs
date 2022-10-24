using Electrimax.Products.Domain;

namespace Electrimax.SalesDepartments.Domain;

public class SalesDepartment
{
    public SalesDepartment()
    {
        // for EF
    }

    [Key] public int Id { get; set; }

    [MaxLength(30)] public string Name { get; set; } = default!;

    public ICollection<Product> Products { get; set; } = new HashSet<Product>();

    public static SalesDepartment Create(string name)
    {
        return new SalesDepartment
        {
            Name = name
        };
    }
}
