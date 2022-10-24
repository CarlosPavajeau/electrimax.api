using Electrimax.Shared.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Electrimax.Test.Shared.DbOptions;

public static class InMemoryDbOptions
{
    public static DbContextOptions<ElectrimaxDbContext> Options => new DbContextOptionsBuilder<ElectrimaxDbContext>()
        .UseInMemoryDatabase(Guid.NewGuid().ToString())
        .Options;
}
