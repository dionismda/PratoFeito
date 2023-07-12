namespace Customers.UnitTests.Application.Customers.Commands.CreateCustomers;

public static class CreateCustomerCommandData
{
    public static IEnumerable<object[]> ValidCreateCustomerCommand =>
        new List<object[]>
        {
            new[] { CreateCustomerCommandBuilder.New().Build() },
            new[] { CreateCustomerCommandBuilder.New().Build() },
            new[] { CreateCustomerCommandBuilder.New().Build() },
        };
}
