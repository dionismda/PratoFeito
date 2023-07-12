namespace Customers.UnitTests.Application.Customers.Commands.CreateCustomers;

public sealed class CreateCustomerCommandBuilder : Builders<CreateCustomerCommandBuilder, CreateCustomerCommand>
{
    private PersonName Name { get; set; }
    private Money OrderLimit { get; set; }

    public CreateCustomerCommandBuilder()
    {
        Name = PersonNameBuilder.New().Build();
        OrderLimit = MoneyBuilder.New().Build();
    }

    public CreateCustomerCommandBuilder ChangeName(PersonName name)
    {
        Name = name;
        return this;
    }

    public CreateCustomerCommandBuilder ChangeOrderLimit(Money orderLimit)
    {
        OrderLimit = orderLimit;
        return this;
    }

    public override CreateCustomerCommand Build()
    {
        return new CreateCustomerCommand(Name, OrderLimit);
    }
}
