using Electrimax.SalesDepartments.Application.Create;
using Electrimax.SalesDepartments.Domain;
using Electrimax.Shared.Infrastructure.Persistence;
using Electrimax.Test.Shared.DbOptions;
using Microsoft.EntityFrameworkCore;

namespace Electrimax.Test.SalesDepartments.Application.Create;

public class CreateSalesDepartmentCommandHandlerTest
{
    private readonly CreateSalesDepartmentCommandHandler _handler;
    private readonly DbContext _context;

    public CreateSalesDepartmentCommandHandlerTest()
    {
        _context = new ElectrimaxDbContext(InMemoryDbOptions.Options);
        _handler = new CreateSalesDepartmentCommandHandler(new SalesDepartmentCreator(_context));
    }
    
    [Fact]
    public async Task WhenCreateSalesDepartmentCommandIsHandled_ThenSalesDepartmentIsCreated()
    {
        // Arrange
        var command = new CreateSalesDepartmentCommand("Sales Department");
        
        // Act
        var result = await _handler.Handle(command, CancellationToken.None);
        
        // Assert
        result.Should().Be(1);
        _context.Set<SalesDepartment>().Count().Should().Be(1);
    }
}
