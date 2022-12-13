namespace Customer.Domain.Customers.Commands;

public class CreateCustomerCommand : ICommand
{
    public PersonNameValueObject PersonName { get; private set; }
    public MoneyValueObject OrderLimit { get; private set; }

    public CreateCustomerCommand(PersonNameValueObject personName, MoneyValueObject orderLimit)
    {
        PersonName = personName;
        OrderLimit = orderLimit;
    }
}
