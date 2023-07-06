namespace Customers.Application.Customers.Commands;

public sealed class DeleteCustomerCommand : ICommand
{
    public Identifier Id { get; private set; } = null!;

    public DeleteCustomerCommand()
    {
    }

    public DeleteCustomerCommand(Identifier id)
    {
        Id = id;
    }
}
