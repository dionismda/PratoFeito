namespace Customers.Application.Customers.Commands;

public sealed class DeleteCustomerOrderCommand : ICommand
{
    public Identifier Id { get; private set; } = null!;

    public DeleteCustomerOrderCommand()
    {
    }

    public DeleteCustomerOrderCommand(Identifier id)
    {
        Id = id;
    }
}
