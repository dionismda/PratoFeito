namespace Customer.Domain.Customers.Aggregates.CustomerOrders.Entities;

public class CustomerOrderEntity : BaseAuditableEntity
{
    public CustomerEntity Customer { get; set; }
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

}
