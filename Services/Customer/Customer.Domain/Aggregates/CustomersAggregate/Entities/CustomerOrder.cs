namespace Customer.Domain.Aggregates.CustomersAggregate.Entities;

public class CustomerOrder : BaseAuditableEntity
{
    public Customer Customer { get; set; }
    public MoneyValueObject OrderTotal { get; private set; }
    public CustomerOrderStateEnum OrderState { get; private set; }

    public CustomerOrder(Customer customer, MoneyValueObject orderTotal) : base()
    {
        Customer = customer;
        OrderTotal = orderTotal;
        OrderState = CustomerOrderStateEnum.Created;

        AddDomainEvent(new CustomerOrderCreateEvent(OrderTotal, Id, Customer.Id));
    }

    public CustomerOrder(Customer customer, 
                         MoneyValueObject orderTotal, 
                         CustomerOrderStateEnum orderState, 
                         DateTime created, 
                         Guid id) : base(created, id)
    {
        Customer = customer;
        OrderTotal = orderTotal;
        OrderState = orderState;
    }
}
