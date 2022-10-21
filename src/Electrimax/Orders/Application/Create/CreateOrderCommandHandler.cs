namespace Electrimax.Orders.Application.Create;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
{
    private readonly OrderCreator _creator;

    public CreateOrderCommandHandler(OrderCreator creator)
    {
        _creator = creator;
    }

    public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken) =>
        await _creator.Create(request);
}
