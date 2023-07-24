namespace Customers.Application._Commons.EventMappers;

public class CustomerIntegrationEventMapper : IntegrationEventMapper, ICustomerIntegrationEventMapper
{
    protected override IntegrationEvent? MapDomainEvent<TDomainEvent>(TDomainEvent domainEvent)
    {
        return domainEvent switch
        {
            CustomerOrderCreatedDomainEvent @event => new CustomerOrderCreatedIntegrationEvent(@event.CustomerOrderId, @event.CustomerId, @event.OrderTotal),
            { } => null,
            _ => throw new ArgumentOutOfRangeException(nameof(domainEvent), domainEvent, null)
        };
    }
}
