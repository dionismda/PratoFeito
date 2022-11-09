namespace Customer.Domain.Aggregates.CustomersAggregate.DomainEvents;

public abstract record CustomerDomainEvent : DomainEvent
{
    public long CustomerID { get; private set; }

    protected CustomerDomainEvent(long customerID)
    {
        CustomerID = customerID;
    }
}
