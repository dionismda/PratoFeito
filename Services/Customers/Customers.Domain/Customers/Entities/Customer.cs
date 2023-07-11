namespace Customers.Domain.Customers.Entities;

public sealed class Customer : AggregateRoot, IValidation
{
    public PersonName Name { get; private set; } = null!;
    public Money OrderLimit { get; private set; } = null!;

    private Customer() : base() { }

    public Customer(PersonName name, Money orderLimit) : this()
    {
        AddDomainEvent(new CustomerCreatedDomainEvent(name, orderLimit, Id));

        Validate();
    }

    public void Apply(CustomerCreatedDomainEvent @event)
    {
        Id = @event.CustomerId;
        Name = @event.Name;
        OrderLimit = @event.OrderLimit;
    }

    public void ChangeName(PersonName name)
    {
        AddDomainEvent(new CustomerNameUpdatedDomainEvent(name, Id));
    }

    public void Apply(CustomerNameUpdatedDomainEvent @event)
    {
        Id = @event.CustomerId;
        Name = @event.Name;
    }

    public void ChangeOrderLimit(Money money)
    {
        AddDomainEvent(new CustomerOrderLimitUpdatedDomainEvent(money, Id));
    }

    public void Apply(CustomerOrderLimitUpdatedDomainEvent @event)
    {
        Id = @event.CustomerId;
        OrderLimit = @event.OrderLimit;
    }

    public void Validate()
    {
        CustomerValidator validator = new();

        var result = validator.Validate(this);

        if (!result.IsValid)
            throw new ValidationDomainException(result.GetErrors());
    }
}
