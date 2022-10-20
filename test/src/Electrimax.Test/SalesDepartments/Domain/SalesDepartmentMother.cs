using Electrimax.SalesDepartments.Domain;

namespace Electrimax.Test.SalesDepartments.Domain;

public static class SalesDepartmentMother
{
    public static SalesDepartment Random()
    {
        var faker = new Faker();

        return SalesDepartment.Create(faker.Random.Word());
    }
}
