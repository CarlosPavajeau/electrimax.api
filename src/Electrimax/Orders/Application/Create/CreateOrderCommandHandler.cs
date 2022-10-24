using Electrimax.Shared.Domain.Orders;
using Mapster;

namespace Electrimax.Orders.Application.Create;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
{
    private readonly OrderCreator _creator;
    private readonly IMediator _mediator;

    public CreateOrderCommandHandler(OrderCreator creator, IMediator mediator)
    {
        _creator = creator;
        _mediator = mediator;
    }

    public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var orderId = await _creator.Create(request);

        await _mediator.Publish(
            new OrderCreated(orderId, request.Items.Adapt<IEnumerable<OrderItemCreated>>()),
            cancellationToken
        );

        return orderId;
    }
}
