namespace Customers.Domain.CustomerOrders.Entities;

public sealed class CustomerOrder : AggregateRoot
{
    public Identifier CustomerId { get; private set; } = null!;
    public CustomerOrderState State { get; private set; } = CustomerOrderState.Created;
    public Money OrderTotal { get; private set; } = null!;

    private CustomerOrder() : base() { }

    public CustomerOrder(Identifier customerId, Money orderTotal) : this()
    {
        AddDomainEvent(new CustomerOrderCreatedDomainEvent(Id, customerId, orderTotal));
    }

    private void Apply(CustomerOrderCreatedDomainEvent @event)
    {
        Id = @event.CustomerOrderId;
        CustomerId = @event.CustomerId;
        OrderTotal = @event.OrderTotal;
        State = CustomerOrderState.Created;
    }

    public void MarkOrderAsDelivered()
    {
        if (State == CustomerOrderState.Created)
        {
            AddDomainEvent(new CustomerOrderDeliveredDomainEvent(Id));
        }
        else
        {
            throw new OrderStateNotCreatedException();
        }
    }

    private void Apply(CustomerOrderDeliveredDomainEvent @event)
    {
        Id = @event.CustomerOrderId;
        State = CustomerOrderState.Delivered;
    }

    public void MarkOrderAsCanceled()
    {
        if (State == CustomerOrderState.Created)
        {
            AddDomainEvent(new CustomerOrderCanceledDomainEvent(Id));
        }
        else
        {
            throw new OrderStateNotCreatedException();
        }
    }

    private void Apply(CustomerOrderCanceledDomainEvent @event)
    {
        Id = @event.CustomerOrderId;
        State = CustomerOrderState.Cancelled;
    }
}
