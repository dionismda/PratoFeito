namespace Customers.UnitTests.Domain.CustomerOrders.Entities;

public sealed class CustomerOrderTest
{
    private CustomerOrder CustomerOrder { get; set; }

    public CustomerOrderTest()
    {
        CustomerOrder = CustomerOrderBuilder.New().Build();
    }

    [Fact]
    public void CustomerOrder_MustCreateObject_WhenIsValid()
    {
        Assert.NotNull(CustomerOrder);
        Assert.NotEmpty(CustomerOrder.DomainEvents.OfType<CustomerOrderCreatedDomainEvent>());
        Assert.Equal(CustomerOrderState.Created, CustomerOrder.State);
    }

    [Fact]
    public void CustomerOrder_MustMarkStateAsDelireved_WhenFunctionMarkOrderAsDeliveredIsCalled()
    {
        CustomerOrder.MarkOrderAsDelivered();
        Assert.NotEmpty(CustomerOrder.DomainEvents.OfType<CustomerOrderDeliveredDomainEvent>());
        Assert.Equal(CustomerOrderState.Delivered, CustomerOrder.State);
    }

    [Fact]
    public void CustomerOrder_MustReturnException_WhenFunctionMarkOrderAsDeliveredIsCalled()
    {
        CustomerOrder.MarkOrderAsDelivered();
        Assert.Throws<OrderStateNotCreatedException>(() =>
        {
            CustomerOrder.MarkOrderAsDelivered();
        });
    }

    [Fact]
    public void CustomerOrder_MustMarkStateAsCanceled_WhenFunctionMarkOrderAsCanceledIsCalled()
    {
        CustomerOrder.MarkOrderAsCanceled();
        Assert.NotEmpty(CustomerOrder.DomainEvents.OfType<CustomerOrderCanceledDomainEvent>());
        Assert.Equal(CustomerOrderState.Cancelled, CustomerOrder.State);
    }

    [Fact]
    public void CustomerOrder_MustReturnException_WhenFunctionMarkOrderAsCanceledIsCalled()
    {
        CustomerOrder.MarkOrderAsCanceled();
        Assert.Throws<OrderStateNotCreatedException>(() =>
        {
            CustomerOrder.MarkOrderAsCanceled();
        });
    }

}
