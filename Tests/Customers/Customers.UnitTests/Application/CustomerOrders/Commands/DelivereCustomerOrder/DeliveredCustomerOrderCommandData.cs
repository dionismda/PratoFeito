namespace Customers.UnitTests.Application.CustomerOrders.Commands.DelivereCustomerOrder;

public static class DeliveredCustomerOrderCommandData
{
    public static IEnumerable<object[]> ValidDeliveredCustomerOrderCommand =>
        new List<object[]>
        {
            new[] { DeliveredCustomerOrderCommandBuilder.New().Build() },
            new[] { DeliveredCustomerOrderCommandBuilder.New().Build() },
            new[] { DeliveredCustomerOrderCommandBuilder.New().Build() },
        };
}
