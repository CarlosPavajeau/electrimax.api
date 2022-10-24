namespace Electrimax.Products.Application.Create;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
{
    private readonly ProductCreator _creator;

    public CreateProductCommandHandler(ProductCreator creator)
    {
        _creator = creator;
    }

    public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken) =>
        await _creator.Create(request.Name, request.Color, request.Quantity, request.Price, request.SalesDepartmentId);
}
