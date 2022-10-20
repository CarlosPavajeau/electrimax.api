namespace Electrimax.SalesDepartments.Application.Create;

public sealed class CreateSalesDepartmentCommandHandler : IRequestHandler<CreateSalesDepartmentCommand, int>
{
    private readonly SalesDepartmentCreator _creator;

    public CreateSalesDepartmentCommandHandler(SalesDepartmentCreator creator)
    {
        _creator = creator;
    }

    public async Task<int> Handle(CreateSalesDepartmentCommand request, CancellationToken cancellationToken) =>
        await _creator.Create(request.Name);
}
