using Electrimax.SalesDepartments.Domain;

namespace Electrimax.SalesDepartments.Application.Create;

public sealed class SalesDepartmentCreator
{
    private readonly DbContext _dbContext;

    public SalesDepartmentCreator(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> Create(string name)
    {
        var salesDepartment = SalesDepartment.Create(name);

        await _dbContext.AddAsync(salesDepartment);
        await _dbContext.SaveChangesAsync();

        return salesDepartment.Id;
    }
}
