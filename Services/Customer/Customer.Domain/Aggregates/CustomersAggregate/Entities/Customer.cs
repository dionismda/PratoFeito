using _Shared.Domain.Exceptions;
using System.Text.Json.Serialization;

namespace Customer.Domain.Aggregates.CustomersAggregate.Entities;

public class Customer : BaseAuditableEntity
{
    public PersonNameValueObject Name { get; private set; }
    public MoneyValueObject OrderList { get; private set; }

    [JsonConstructor]
    protected Customer() { }

    public Customer(PersonNameValueObject name, MoneyValueObject orderList) : base()
    {
        Name = name;
        OrderList = orderList;
        AddDomainEvent(new CustomerCreatedDomainEvent(name, orderList, Id));
    }

    public Customer(PersonNameValueObject name, MoneyValueObject orderList, DateTime created, string createdBy, Guid id) : base(created, createdBy, id)
    {
        Name = name;
        OrderList = orderList;
    }

    public void CreateCustomerOrder(MoneyValueObject OrderTotal)
    {
        if(!OrderTotal.IsGreatThenOrEquals(OrderList))
        {
            new CustomerOrder(this, OrderList);
        }
        else
        {
            throw new DomainException("Customer limit is reached");
        }           
    }
}
