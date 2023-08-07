namespace Customers.Infrastructure._Commons.Interceptors;

public class CustomerEventsInterceptor : EventsInterceptor
{
    public CustomerEventsInterceptor(IMediator mediator, ICustomerIntegrationEventMapper mapper) : base(mediator, mapper)
    {
    }
}
