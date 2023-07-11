namespace Customers.Domain.CustomerOrders.Entities;

public sealed class CustomerOrder : AggregateRoot, IValidation
{
    public Identifier CustomerId { get; private set; } = null!;
    public CustomerOrderState State { get; private set; } = CustomerOrderState.Created;
    public Money OrderTotal { get; private set; } = null!;

    private CustomerOrder() : base() { }

    public CustomerOrder(Identifier customerId, Money orderTotal) : this()
    {
        AddDomainEvent(new CustomerOrderCreatedDomainEvent(Id, customerId, orderTotal));

        Validate();
    }

    public void Apply(CustomerOrderCreatedDomainEvent @event)
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
            //Todo criar exception especifica?
            throw new Exception("The corrent state is not Created");
        }
    }

    public void Apply(CustomerOrderDeliveredDomainEvent @event)
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
            //Todo criar exception especifica?
            throw new Exception("The corrent state is not Created");
        }
    }

    public void Apply(CustomerOrderCanceledDomainEvent @event)
    {
        Id = @event.CustomerOrderId;
        State = CustomerOrderState.Cancelled;
    }

    public void Validate()
    {
        CustomerOrdersValidator validator = new();

        var result = validator.Validate(this);

        if (!result.IsValid)
            throw new ValidationDomainException(result.GetErrors());
    }
}
