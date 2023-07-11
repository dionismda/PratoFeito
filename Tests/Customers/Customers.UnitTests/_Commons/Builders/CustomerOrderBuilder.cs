namespace Customers.UnitTests._Commons.Builders;

public sealed class CustomerOrderBuilder : Builders<CustomerOrderBuilder, CustomerOrder>
{
    private Identifier CustomerId { get; set; }
    private Money OrderTotal { get; set; }

    public CustomerOrderBuilder()
    {
        CustomerId = Identifier.CreateNew();
        OrderTotal = MoneyBuilder.New().Build();
    }

    public CustomerOrderBuilder ChangeOrderTotal(Money orderTotal)
    {
        OrderTotal = orderTotal;
        return this;
    }

    public override CustomerOrder Build()
    {
        return new CustomerOrder(CustomerId, OrderTotal);
    }
}
