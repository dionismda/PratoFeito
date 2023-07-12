namespace Customers.UnitTests.Application.Customers.Commands.DeleteCustomers;

public sealed class DeleteCustomerOrderCommandBuilder : Builders<DeleteCustomerOrderCommandBuilder, DeleteCustomerOrderCommand>
{
    private Identifier Id { get; set; }

    public DeleteCustomerOrderCommandBuilder()
    {
        Id = Identifier.CreateNew();
    }

    public override DeleteCustomerOrderCommand Build()
    {
        return new DeleteCustomerOrderCommand(Id);
    }
}
