namespace Customers.UnitTests.Application.CustomerOrders.Commands.DelivereCustomerOrder;

public sealed class DeliveredCustomerOrderCommandBuilder : Builders<DeliveredCustomerOrderCommandBuilder, DeliveredCustomerOrderCommand>
{
    private Identifier Id { get; set; }

    public DeliveredCustomerOrderCommandBuilder()
    {
        Id = Identifier.CreateNew();
    }

    public override DeliveredCustomerOrderCommand Build()
    {
        return new DeliveredCustomerOrderCommand(Id);
    }
}
