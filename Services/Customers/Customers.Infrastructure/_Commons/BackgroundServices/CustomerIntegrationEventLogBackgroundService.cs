namespace Customers.Infrastructure._Commons.BackgroundServices;

public sealed class CustomerIntegrationEventLogBackgroundService : IntegrationEventLogBackgroundService
{
    public CustomerIntegrationEventLogBackgroundService(
        ICustomerIntegrationEventLogService integrationEventLogService,
        ICustomerEventBusAws eventBusAws,
        ICustomerIntegrationEventMapper integrationEventMapper) : base(integrationEventLogService, eventBusAws, integrationEventMapper)
    {
    }
}
