namespace Customers.UnitTests.Application.CustomerOrders.Commands.CreateCustomerOrder;

public static class CreateCustomerOrderCommandData
{
    public static IEnumerable<object[]> ValidCreateCustomerOrderCommand =>
        new List<object[]>
        {
            new[] { CreateCustomerOrderCommandBuilder.New().Build() },
            new[] { CreateCustomerOrderCommandBuilder.New().Build() },
            new[] { CreateCustomerOrderCommandBuilder.New().Build() },
        };
}
