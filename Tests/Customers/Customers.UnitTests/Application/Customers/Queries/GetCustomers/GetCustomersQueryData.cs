namespace Customers.UnitTests.Application.Customers.Queries.GetCustomers;

public static class GetCustomersQueryData
{
    public static IEnumerable<object[]> ValidGetCustomersQuery =>
        new List<object[]>
        {
                new[] { new GetCustomersQuery() },
                new[] { new GetCustomersQuery() },
                new[] { new GetCustomersQuery() },
        };
}
