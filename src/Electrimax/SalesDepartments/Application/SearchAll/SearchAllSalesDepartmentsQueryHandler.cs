using Mapster;

namespace Electrimax.SalesDepartments.Application.SearchAll;

public class
    SearchAllSalesDepartmentsQueryHandler : IRequestHandler<SearchAllSalesDepartmentsQuery,
        IEnumerable<SalesDepartmentResponse>>
{
    private readonly SalesDepartmentSearcher _searcher;

    public SearchAllSalesDepartmentsQueryHandler(SalesDepartmentSearcher searcher)
    {
        _searcher = searcher;
    }

    public async Task<IEnumerable<SalesDepartmentResponse>> Handle(SearchAllSalesDepartmentsQuery request,
        CancellationToken cancellationToken)
    {
        var salesDepartments = await _searcher.SearchAll();

        return salesDepartments.Adapt<IEnumerable<SalesDepartmentResponse>>();
    }
}
