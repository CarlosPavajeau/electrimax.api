using Electrimax.Products.Application.Create;
using Electrimax.Products.Domain;
using Electrimax.Shared.Infrastructure.Persistence;
using Electrimax.Test.Shared.DbOptions;
using Microsoft.EntityFrameworkCore;

namespace Electrimax.Test.Products.Application.Create;

public class CreateProductCommandHandlerTest
{
    private readonly CreateProductCommandHandler _handler;
    private readonly DbContext _context;

    public CreateProductCommandHandlerTest()
    {
        _context = new ElectrimaxDbContext(InMemoryDbOptions.Options);
        _handler = new CreateProductCommandHandler(new ProductCreator(_context));
    }

    [Fact]
    public async Task WhenCreateProductCommandIsHandled_ThenProductIsCreated()
    {
        // Arrange
        var command = new CreateProductCommand("Test product", "Test description", 10, 10.0m, 1);
        
        // Act
        var result = await _handler.Handle(command, CancellationToken.None);
        
        // Assert
        result.Should().NotBeEmpty();
        _context.Set<Product>().Count().Should().Be(1);
    }
}
