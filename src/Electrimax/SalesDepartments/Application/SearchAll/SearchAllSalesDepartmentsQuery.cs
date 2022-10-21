namespace Electrimax.SalesDepartments.Application.SearchAll;

public sealed record SearchAllSalesDepartmentsQuery() : IRequest<IEnumerable<SalesDepartmentResponse>>;
