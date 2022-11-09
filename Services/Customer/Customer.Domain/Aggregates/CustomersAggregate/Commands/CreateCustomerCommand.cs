namespace Customer.Domain.Aggregates.CustomersAggregate.Commands;

public class CreateCustomerCommand
{
    public PersonNameValueObject PersonName { get; private set; }
    public MoneyValueObject OrderLimit { get; private set; }

    public CreateCustomerCommand(PersonNameValueObject personName, MoneyValueObject orderLimit)
    {
        PersonName = personName;
        OrderLimit = orderLimit;
    }
}
