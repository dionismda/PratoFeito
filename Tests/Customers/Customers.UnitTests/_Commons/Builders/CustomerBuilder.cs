namespace Customers.UnitTests._Commons.Builders;

public class CustomerBuilder : Builders<CustomerBuilder, Customer>
{
    private PersonName Name { get; set; }
    private Money OrderLimit { get; set; }

    public CustomerBuilder()
    {
        Name = PersonNameBuilder.New().Build();
        OrderLimit = MoneyBuilder.New().Build();
    }

    public CustomerBuilder ChangeName(PersonName name)
    {
        Name = name;
        return this;
    }

    public CustomerBuilder ChangeOrderLimit(Money orderLimit)
    {
        OrderLimit = orderLimit;
        return this;
    }

    public override Customer Build()
    {
        return new Customer(Name, OrderLimit);
    }
}
