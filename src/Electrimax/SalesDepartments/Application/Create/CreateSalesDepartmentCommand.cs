namespace Electrimax.SalesDepartments.Application.Create;

public sealed record CreateSalesDepartmentCommand(string Name) : IRequest<int>;
