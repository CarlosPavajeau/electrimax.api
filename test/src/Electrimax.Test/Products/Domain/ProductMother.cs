using Electrimax.Products.Domain;

namespace Electrimax.Test.Products.Domain;

public static class ProductMother
{
    public static Product Random()
    {
        var faker = new Faker();

        return Product.Create(
            faker.Random.Word(),
            faker.Random.Word(),
            faker.Random.Int(1, 1000),
            faker.Random.Decimal(1, 1000),
            faker.Random.Int(1, 10)
        );
    }
}
