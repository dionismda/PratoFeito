namespace Customer.Domain.Aggregates.CustomersAggregate.DomainEvents;

public abstract record CustomerDomainEvent : DomainEvent
{
    public Guid CustomerID { get; private set; }

    protected CustomerDomainEvent(Guid customerID)
    {
        CustomerID = customerID;
    }
}
