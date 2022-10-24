using Electrimax.Products.Application.SearchAll;
using Electrimax.Products.Domain;
using Electrimax.Shared.Infrastructure.Persistence;
using Electrimax.Test.Products.Domain;
using Electrimax.Test.Shared.DbOptions;
using Microsoft.EntityFrameworkCore;

namespace Electrimax.Test.Products.Application.SearchAll;

public class SearchAllProductsQueryHandlerTest : IAsyncLifetime
{
    private readonly SearchAllProductsQueryHandler _handler;
    private readonly DbContext _context;

    public SearchAllProductsQueryHandlerTest()
    {
        _context = new ElectrimaxDbContext(InMemoryDbOptions.Options);
        _handler = new SearchAllProductsQueryHandler(new ProductsSearcher(_context));
    }

    [Fact]
    public async Task WhenSearchAllProducts_ThenReturnAllProducts()
    {
        // Arrange
        var query = new SearchAllProductsQuery();

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().NotBeNull()
            .And.HaveCount(3);
    }

    public async Task InitializeAsync()
    {
        await _context.Set<Product>()
            .AddRangeAsync(
                ProductMother.Random(),
                ProductMother.Random(),
                ProductMother.Random()
            );

        await _context.SaveChangesAsync();
    }

    public Task DisposeAsync() => Task.CompletedTask;
}
