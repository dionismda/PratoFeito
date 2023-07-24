namespace Customers.Infrastructure._Commons.EventBus;

public sealed class CustomerEventBusAws : EventBusAws.EventBusAws, ICustomerEventBusAws, IDisposable
{
    public CustomerEventBusAws(
        ICustomerEventBusSubscriptionsManager subsManager,
        IPollyPolicy pollyPolicy,
        IAmazonSimpleNotificationService amazonSNS,
        IAmazonSQS amazonSQS) : base(subsManager, pollyPolicy, amazonSNS, amazonSQS)
    {
    }

    public void Dispose()
    {
        SubsManager.Clear();
    }
}
