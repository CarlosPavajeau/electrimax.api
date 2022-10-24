using Electrimax.SalesDepartments.Domain;

namespace Electrimax.SalesDepartments.Application.SearchAll;

public class SalesDepartmentSearcher
{
    private readonly DbContext _dbContext;

    public SalesDepartmentSearcher(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<SalesDepartment>> SearchAll()
    {
        return await _dbContext.Set<SalesDepartment>().ToListAsync();
    }
}
