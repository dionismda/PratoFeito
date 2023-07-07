namespace Customers.Application.Customers.Commands.UpdateCustomers;

public sealed class UpdateCustomerCommand : ICommand<Customer>
{
    public Identifier Id { get; private set; } = null!;
    public PersonName Name { get; private set; } = null!;
    public Money OrderLimit { get; private set; } = null!;

    public UpdateCustomerCommand() { }

    public UpdateCustomerCommand(Identifier id, PersonName name, Money orderLimit)
    {
        Id = id;
        Name = name;
        OrderLimit = orderLimit;
    }
}