namespace Customers.Infrastructure._Commons.Services;

public sealed class CustomerIntegrationEventLogService : IntegrationEventLogService, ICustomerIntegrationEventLogService
{
    public CustomerIntegrationEventLogService(CustomersContext integrationEventLogContext) : base(integrationEventLogContext)
    {
    }
}
