namespace Customers.UnitTests.Application.Customers.Queries.GetCustomerById;

public static class GetCustomerByIdQueryData
{
    public static IEnumerable<object[]> ValidGetCustomerByIdQuery =>
        new List<object[]>
        {
                new[] { GetCustomerByIdQueryBuilder.New().Build() },
                new[] { GetCustomerByIdQueryBuilder.New().Build() },
                new[] { GetCustomerByIdQueryBuilder.New().Build() },
        };
}