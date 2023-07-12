namespace Customers.UnitTests.Application.Customers.Commands.UpdateCustomers;

public static class UpdateCustomerCommandData
{
    public static IEnumerable<object[]> ValidUpdateCustomerCommand =>
        new List<object[]>
        {
                new[] { UpdateCustomerCommandBuilder.New().Build() },
                new[] { UpdateCustomerCommandBuilder.New().Build() },
                new[] { UpdateCustomerCommandBuilder.New().Build() },
        };
}
