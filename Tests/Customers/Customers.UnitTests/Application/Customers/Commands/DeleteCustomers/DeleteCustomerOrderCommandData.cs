namespace Customers.UnitTests.Application.Customers.Commands.DeleteCustomers;

public static class DeleteCustomerOrderCommandData
{
    public static IEnumerable<object[]> ValidDeleteCustomerOrderCommand =>
        new List<object[]>
        {
            new[] { DeleteCustomerOrderCommandBuilder.New().Build() },
            new[] { DeleteCustomerOrderCommandBuilder.New().Build() },
            new[] { DeleteCustomerOrderCommandBuilder.New().Build() },
        };
}
