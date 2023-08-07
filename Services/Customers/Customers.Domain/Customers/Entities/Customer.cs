namespace Customers.Domain.Customers.Entities;

public sealed class Customer : AggregateRoot
{
    public PersonName Name { get; private set; } = null!;
    public Money OrderLimit { get; private set; } = null!;

    private Customer() : base() { }

    public Customer(PersonName name, Money orderLimit) : this()
    {
        AddDomainEvent(new CustomerCreatedDomainEvent(name, orderLimit, Id));
    }

    private void Apply(CustomerCreatedDomainEvent @event)
    {
        Id = @event.CustomerId;
        Name = @event.Name;
        OrderLimit = @event.OrderLimit;
    }

    public void ChangeName(PersonName name)
    {
        AddDomainEvent(new CustomerNameUpdatedDomainEvent(name, Id));
    }

    private void Apply(CustomerNameUpdatedDomainEvent @event)
    {
        Id = @event.CustomerId;
        Name = @event.Name;
    }

    public void ChangeOrderLimit(Money money)
    {
        AddDomainEvent(new CustomerOrderLimitUpdatedDomainEvent(money, Id));
    }

    private void Apply(CustomerOrderLimitUpdatedDomainEvent @event)
    {
        Id = @event.CustomerId;
        OrderLimit = @event.OrderLimit;
    }
}
