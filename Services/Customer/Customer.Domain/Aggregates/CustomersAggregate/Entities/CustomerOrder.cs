using _Shared.Domain.Exceptions;
using System.Text.Json.Serialization;

namespace Customer.Domain.Aggregates.CustomersAggregate.Entities;

public class CustomerOrder : BaseAuditableEntity
{
    public Customer Customer { get; set; }
    public MoneyValueObject OrderTotal { get; private set; }
    public CustomerOrderStateEnum OrderState { get; private set; }

    [JsonConstructor]
    protected CustomerOrder() { }
    public CustomerOrder(Customer customer, MoneyValueObject orderTotal) : base()
    {
        Customer = customer;
        OrderTotal = orderTotal;
        OrderState = CustomerOrderStateEnum.Created;

        AddDomainEvent(new CustomerOrderCreateDomainEvent(OrderTotal, Id, Customer.Id));
    }

    public CustomerOrder(Customer customer, 
                         MoneyValueObject orderTotal, 
                         CustomerOrderStateEnum orderState, 
                         DateTime created, 
                         string createdBy,
                         Guid id) : base(created, createdBy, id)
    {
        Customer = customer;
        OrderTotal = orderTotal;
        OrderState = orderState;
    }

    public void AsDevlivered()
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
    }

}
