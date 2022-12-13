namespace Customer.Domain.Customers.Entities;

public class CustomerEntity : BaseEntity, IAggregateRoot, IValidation
{
    public PersonNameValueObject Name { get; private set; }
    public MoneyValueObject OrderLimit { get; private set; }

    private List<CustomerOrderEntity> _customerOrders;
    public IReadOnlyCollection<CustomerOrderEntity>? CustomerOrders
    {
        get => _customerOrders?.AsReadOnly();
        private set => _customerOrders = value?.ToList();
    }

    protected CustomerEntity() : base() { }

    public CustomerEntity(PersonNameValueObject name, MoneyValueObject orderLimit) : this()
    {
        Name = name;
        OrderLimit = orderLimit;

        Validate();

        AddDomainEvent(new CustomerCreatedDomainEvent(name, orderLimit, Id));
    }

    public CustomerEntity CreateCustomerOrder(MoneyValueObject OrderTotal)
    {
        if (!OrderTotal.IsGreatThenOrEquals(OrderLimit))
        {
            _customerOrders.Add(new CustomerOrderEntity(this, OrderLimit));
        }
        else
        {
            throw new DomainException("Customer limit is reached");
        }

        return this;
    }

    public void Validate()
    {
        CustomerEntityValidator validator = new();

        var result = validator.Validate(this);

        if (!result.IsValid)
            throw new FluentValidationException(result.Errors);
    }
}
