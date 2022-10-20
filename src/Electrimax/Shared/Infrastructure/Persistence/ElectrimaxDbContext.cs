using Electrimax.SalesDepartments.Domain;

namespace Electrimax.Shared.Infrastructure.Persistence;

public class ElectrimaxDbContext : DbContext
{
    public ElectrimaxDbContext(DbContextOptions<ElectrimaxDbContext> options) : base(options)
    {
    }

    public DbSet<SalesDepartment> SalesDepartments { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ElectrimaxDbContext).Assembly);
    }
}
