namespace Customers.UnitTests.Application.CustomerOrders.Commands.CreateCustomerOrder;

public class CreateCustomerOrderCommandBuilder : Builders<CreateCustomerOrderCommandBuilder, CreateCustomerOrderCommand>
{
    private Identifier CustomerId { get; set; }
    private Money OrderTotal { get; set; }

    public CreateCustomerOrderCommandBuilder()
    {
        CustomerId = Identifier.CreateNew();
        OrderTotal = MoneyBuilder.New().Build();
    }

    public CreateCustomerOrderCommandBuilder ChangeOrderTotal(Money orderTotal)
    {
        OrderTotal = orderTotal;
        return this;
    }

    public override CreateCustomerOrderCommand Build()
    {
        return new CreateCustomerOrderCommand(CustomerId, OrderTotal);
    }
}
