namespace Customers.Application.Customers.Commands.UpdateCustomers;

public sealed class UpdateCustomerCommand : CustomerCommand
{
    public Identifier Id { get; private set; } = null!;

    private UpdateCustomerCommand() : base() { }

    public UpdateCustomerCommand(Identifier id, PersonName name, Money orderLimit) : base(name, orderLimit)
    {
        Id = id;
    }
}