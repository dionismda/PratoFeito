namespace Customers.Application.Customers.Commands.CreateCustomers;

public sealed class CreateCustomerCommand : ICommand<Customer>
{
    public PersonName Name { get; private set; } = null!;
    public Money OrderLimit { get; private set; } = null!;

    private CreateCustomerCommand() { }

    public CreateCustomerCommand(PersonName name, Money orderLimit) : this()
    {
        Name = name;
        OrderLimit = orderLimit;
    }
}