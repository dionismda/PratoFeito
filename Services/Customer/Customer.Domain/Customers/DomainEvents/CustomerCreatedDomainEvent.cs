namespace Customer.Domain.Customers.DomainEvents;

public record CustomerCreatedDomainEvent : DomainEvent
{
    public Guid CustomerId { get; private set; }
    public PersonNameValueObject PersonName { get; private set; }
    public MoneyValueObject MoneyLimit { get; private set; }

    public CustomerCreatedDomainEvent(PersonNameValueObject personName, MoneyValueObject moneyLimit, Guid customerId)
    {
        PersonName = personName;
        MoneyLimit = moneyLimit;
        CustomerId = customerId;
    }
}
