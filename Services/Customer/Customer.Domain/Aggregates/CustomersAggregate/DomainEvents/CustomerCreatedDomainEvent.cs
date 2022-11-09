namespace Customer.Domain.Aggregates.CustomersAggregate.DomainEvents;

public record CustomerCreatedDomainEvent : CustomerDomainEvent
{
    public PersonNameValueObject PersonName { get; private set; }
    public MoneyValueObject MoneyLimit { get; private set; }

    public CustomerCreatedDomainEvent(PersonNameValueObject personName, MoneyValueObject moneyLimit, long customerId) : base(customerId)
    {
        PersonName = personName;
        MoneyLimit = moneyLimit;
    }
}
