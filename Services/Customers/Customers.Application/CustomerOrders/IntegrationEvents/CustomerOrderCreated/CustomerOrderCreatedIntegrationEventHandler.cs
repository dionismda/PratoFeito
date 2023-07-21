namespace Customers.Application.CustomerOrders.IntegrationEvents.CustomerOrderCreated;

public class CustomerOrderCreatedIntegrationEventHandler : IIntegrationEventHandler<CustomerOrderCreatedIntegrationEvent>
{
    public Task Handle(CustomerOrderCreatedIntegrationEvent @event)
    {
        throw new NotImplementedException();
    }
}
