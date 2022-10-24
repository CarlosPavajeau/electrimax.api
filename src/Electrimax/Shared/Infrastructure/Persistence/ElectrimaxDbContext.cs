using Electrimax.Orders.Domain;
using Electrimax.Products.Domain;
using Electrimax.SalesDepartments.Domain;

namespace Electrimax.Shared.Infrastructure.Persistence;

public class ElectrimaxDbContext : DbContext
{
    public ElectrimaxDbContext(DbContextOptions<ElectrimaxDbContext> options) : base(options)
    {
    }

    public DbSet<SalesDepartment> SalesDepartments { get; set; } = default!;
    public DbSet<Product> Products { get; set; } = default!;
    public DbSet<Order> Orders { get; set; } = default!;
    public DbSet<OrderItem> OrderItems { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ElectrimaxDbContext).Assembly);
    }
}
