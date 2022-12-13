namespace Customer.Domain.Customers.Entities;

public class CustomerEntity : BaseAuditableEntity, IAggregateRoot, IValidation
{
    public PersonNameValueObject Name { get; private set; }
    public MoneyValueObject OrderList { get; private set; }


    protected CustomerEntity() : base() { }

    public CustomerEntity(PersonNameValueObject name, MoneyValueObject orderList) : this()
    {
        Name = name;
        OrderList = orderList;

        AddDomainEvent(new CustomerCreatedDomainEvent(name, orderList, Id));
    }

    public CustomerEntity CreateCustomerOrder(MoneyValueObject OrderTotal)
    {
        if (!OrderTotal.IsGreatThenOrEquals(OrderList))
        {
            new CustomerOrderEntity(this, OrderList);
        }
        else
        {
            throw new DomainException("Customer limit is reached");
        }

        return this;
    }

    public void Validate()
    {
        throw new NotImplementedException();
    }
}
