namespace Customer.Domain.Aggregates.CustomersAggregate.Entities;

public class Customer : BaseAuditableEntity
{
    public PersonNameValueObject Name { get; private set; }
    public MoneyValueObject OrderList { get; private set; }

    public Customer(PersonNameValueObject name, MoneyValueObject orderList) : base()
    {
        Name = name;
        OrderList = orderList;
        AddDomainEvent(new CustomerCreatedDomainEvent(name, orderList, Id));
    }

    public Customer(PersonNameValueObject name, MoneyValueObject orderList, DateTime created, Guid id) : base(created, id)
    {
        Name = name;
        OrderList = orderList;
    }

}
