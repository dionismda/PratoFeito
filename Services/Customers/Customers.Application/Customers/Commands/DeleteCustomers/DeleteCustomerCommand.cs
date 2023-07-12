namespace Customers.Application.Customers.Commands.DeleteCustomers;

public sealed class DeleteCustomerOrderCommand : ICommand
{
    public Identifier Id { get; private set; } = null!;

    private DeleteCustomerOrderCommand()
    {
    }

    public DeleteCustomerOrderCommand(Identifier id) : this()
    {
        Id = id;
    }
}
