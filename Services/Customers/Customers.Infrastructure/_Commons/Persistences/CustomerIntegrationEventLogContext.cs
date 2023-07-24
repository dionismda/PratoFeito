namespace Customers.Infrastructure._Commons.Persistences;

public sealed class CustomerIntegrationEventLogContext : IntegrationEventLogDbContext
{
    public CustomerIntegrationEventLogContext(
        DbContextOptions<CustomerIntegrationEventLogContext> options,
        IConfiguration configuration,
        ICustomerIntegrationEventMapper customerIntegrationEventMapper) : base(options, configuration, customerIntegrationEventMapper)
    {
        Schema = nameof(ContextEnum.Customers).ToLower();
    }
}