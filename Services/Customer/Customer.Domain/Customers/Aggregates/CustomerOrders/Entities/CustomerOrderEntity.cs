using Customer.Domain.Customers.Aggregates.CustomerOrders.Entities.Validators;

namespace Customer.Domain.Customers.Aggregates.CustomerOrders.Entities;

public class CustomerOrderEntity : BaseEntity, IValidation
{
    public CustomerEntity Customer { get; private set; }
    public MoneyValueObject OrderTotal { get; private set; }
    public CustomerOrderStateEnum OrderState { get; private set; }

    protected CustomerOrderEntity() : base() { }

    public CustomerOrderEntity(CustomerEntity customer, MoneyValueObject orderTotal) : this()
    {
        Customer = customer;
        OrderTotal = orderTotal;
        OrderState = CustomerOrderStateEnum.Created;

        AddDomainEvent(new CustomerOrderCreateDomainEvent(OrderTotal, Id, Customer.Id));
    }

    public CustomerOrderEntity AsDevlivered()
    {
        if (CustomerOrderStateEnum.Created == OrderState)
        {
            OrderState = CustomerOrderStateEnum.Devlivered;
            AddDomainEvent(new CustomerOrderDeliveredDomainEvent(Customer.Id, Id));
        }
        else
        {
            throw new DomainException("The current order state is not Created");
        }

        return this;
    }

    public void Validate()
    {
        CustomerOrderEntityValidator validator = new();

        var result = validator.Validate(this);

        if (!result.IsValid)
            throw new FluentValidationException(result.Errors);
    }
}
