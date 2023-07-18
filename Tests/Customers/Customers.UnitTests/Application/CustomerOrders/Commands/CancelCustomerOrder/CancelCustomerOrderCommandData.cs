namespace Customers.UnitTests.Application.CustomerOrders.Commands.CancelCustomerOrder;

public static class CancelCustomerOrderCommandData
{
    public static IEnumerable<object[]> ValidCancelCustomerOrderCommand =>
        new List<object[]>
        {
            new[] { CancelCustomerOrderCommandBuilder.New().Build() },
            new[] { CancelCustomerOrderCommandBuilder.New().Build() },
            new[] { CancelCustomerOrderCommandBuilder.New().Build() },
        };
}
