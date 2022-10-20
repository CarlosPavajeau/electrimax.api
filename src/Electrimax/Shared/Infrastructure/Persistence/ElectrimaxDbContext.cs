using Microsoft.EntityFrameworkCore;

namespace Electrimax.Shared.Infrastructure.Persistence;

public class ElectrimaxDbContext : DbContext
{
    public ElectrimaxDbContext(DbContextOptions<ElectrimaxDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ElectrimaxDbContext).Assembly);
    }
}
