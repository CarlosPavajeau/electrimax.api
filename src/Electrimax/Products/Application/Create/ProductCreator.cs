using Electrimax.Products.Domain;

namespace Electrimax.Products.Application.Create;

public class ProductCreator
{
    private readonly DbContext _context;

    public ProductCreator(DbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Create(string name, string color, int quantity, decimal price, int salesDepartmentId)
    {
        var product = Product.Create(name, color, quantity, price, salesDepartmentId);

        await _context.AddAsync(product);
        await _context.SaveChangesAsync();

        return product.Id;
    }
}
