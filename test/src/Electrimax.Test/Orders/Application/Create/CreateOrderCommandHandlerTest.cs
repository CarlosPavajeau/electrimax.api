using Electrimax.Orders.Application.Create;
using Electrimax.Orders.Domain;
using Electrimax.Shared.Infrastructure.Persistence;
using Electrimax.Test.Shared.DbOptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Electrimax.Test.Orders.Application.Create;

public class CreateOrderCommandHandlerTest
{
    private readonly CreateOrderCommandHandler _handler;
    private readonly DbContext _context;

    public CreateOrderCommandHandlerTest()
    {
        _context = new ElectrimaxDbContext(InMemoryDbOptions.Options);
        _handler = new CreateOrderCommandHandler(new OrderCreator(_context), Mock.Of<IMediator>());
    }

    [Fact]
    public async Task WhenCreateOrderCommandIsHandled_ThenOrderIsCreated()
    {
        // Arrange
        var itemCommand = new CreateOrderItemCommand(Guid.NewGuid(), 1, 1000m);
        var command = new CreateOrderCommand("12345678", "Colombia", new[] {itemCommand});

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        result.Should().NotBeEmpty();
        _context.Set<Order>().Count().Should().Be(1);
    }
}
