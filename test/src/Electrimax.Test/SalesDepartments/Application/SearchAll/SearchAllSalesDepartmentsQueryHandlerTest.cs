using Electrimax.SalesDepartments.Application.SearchAll;
using Electrimax.SalesDepartments.Domain;
using Electrimax.Shared.Infrastructure.Persistence;
using Electrimax.Test.SalesDepartments.Domain;
using Electrimax.Test.Shared.DbOptions;
using Microsoft.EntityFrameworkCore;

namespace Electrimax.Test.SalesDepartments.Application.SearchAll;

public class SearchAllSalesDepartmentsQueryHandlerTest : IAsyncLifetime
{
    private readonly SearchAllSalesDepartmentsQueryHandler _handler;
    private readonly DbContext _context;

    public SearchAllSalesDepartmentsQueryHandlerTest()
    {
        _context = new ElectrimaxDbContext(InMemoryDbOptions.Options);
        _handler = new SearchAllSalesDepartmentsQueryHandler(new SalesDepartmentSearcher(_context));
    }

    // Setup


    [Fact]
    public async Task WhenSearchAllSalesDepartments_ThenReturnAllSalesDepartments()
    {
        // Arrange
        var query = new SearchAllSalesDepartmentsQuery();

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(3);
    }

    public async Task InitializeAsync()
    {
        await _context.Set<SalesDepartment>()
            .AddRangeAsync(
                SalesDepartmentMother.Random(),
                SalesDepartmentMother.Random(),
                SalesDepartmentMother.Random()
            );

        await _context.SaveChangesAsync();
    }

    public Task DisposeAsync() => Task.CompletedTask;
}
