namespace Customers.Application.Customers.Commands;

public sealed class CreateCustomerCommand : ICommand<Customer>
{
    public PersonName Name { get; private set; } = null!;
    public Money OrderLimit { get; private set; } = null!;

    public CreateCustomerCommand() { }

    public CreateCustomerCommand(PersonName name, Money orderLimit)
    {
        Name = name;
        OrderLimit = orderLimit;
    }
}