namespace Customers.Infrastructure._Commons.Services;

public sealed class CustomerIntegrationEventLogService : IntegrationEventLogService, ICustomerIntegrationEventLogService
{
    public CustomerIntegrationEventLogService(CustomerIntegrationEventLogContext integrationEventLogContext) : base(integrationEventLogContext)
    {
    }
}
