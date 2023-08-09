namespace Customers.Application.Customers.Commands.CreateCustomers;

public sealed class CreateCustomerCommand : CustomerCommand
{
    private CreateCustomerCommand() : base() { }

    public CreateCustomerCommand(PersonName name, Money orderLimit) : base(name, orderLimit)
    {
    }
}