namespace Customers.UnitTests.Application.CustomerOrders.Commands.CancelCustomerOrder;

public sealed class CancelCustomerOrderCommandBuilder : Builders<CancelCustomerOrderCommandBuilder, CancelCustomerOrderCommand>
{
    private Identifier Id { get; set; }

    public CancelCustomerOrderCommandBuilder()
    {
        Id = Identifier.CreateNew();
    }

    public override CancelCustomerOrderCommand Build()
    {
        return new CancelCustomerOrderCommand(Id);
    }
}
