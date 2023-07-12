namespace Customers.UnitTests.Application.Customers.Queries.GetCustomerOrdersByCustomerId;

public static class GetCustomerOrdersByCustomerIdQueryData
{
    public static IEnumerable<object[]> ValidGetCustomerOrdersByCustomerIdQuery =>
        new List<object[]>
        {
                new[] { GetCustomerOrdersByCustomerIdQueryBuilder.New().Build() },
                new[] { GetCustomerOrdersByCustomerIdQueryBuilder.New().Build() },
                new[] { GetCustomerOrdersByCustomerIdQueryBuilder.New().Build() },
        };
}
