using Electrimax.Orders.Application.SearchAll;
using Electrimax.Orders.Domain;
using Electrimax.Shared.Infrastructure.Persistence;
using Electrimax.Test.Orders.Domain;
using Electrimax.Test.Shared.DbOptions;
using Microsoft.EntityFrameworkCore;

namespace Electrimax.Test.Orders.Application.SearchAll;

public class SearchAllOrdersQueryHandlerTest : IAsyncLifetime
{
    private readonly SearchAllOrdersQueryHandler _handler;
    private readonly DbContext _context;

    public SearchAllOrdersQueryHandlerTest()
    {
        _context = new ElectrimaxDbContext(InMemoryDbOptions.Options);
        _handler = new SearchAllOrdersQueryHandler(new OrdersSearcher(_context));
    }

    [Fact]
    public async Task WhenSearchAllOrders_ThenReturnAllOrders()
    {
        // Arrange
        var query = new SearchAllOrdersQuery();

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().NotBeEmpty()
            .And.HaveCount(3);
    }

    public async Task InitializeAsync()
    {
        await _context.Set<Order>()
            .AddRangeAsync(
                OrderMother.Random(),
                OrderMother.Random(),
                OrderMother.Random()
            );

        await _context.SaveChangesAsync();
    }

    public Task DisposeAsync() => Task.CompletedTask;
}
