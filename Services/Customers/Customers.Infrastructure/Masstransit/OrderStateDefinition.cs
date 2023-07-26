using MassTransit;

namespace Customers.Infrastructure.Masstransit;

public class OrderStateDefinition :
    SagaDefinition<OrderState>
{
    private readonly IServiceProvider _provider;

    public OrderStateDefinition(IServiceProvider provider)
    {
        _provider = provider;
    }

    protected override void ConfigureSaga(
        IReceiveEndpointConfigurator endpointConfigurator,
        ISagaConfigurator<OrderState> consumerConfigurator)
    {
        endpointConfigurator.UseMessageRetry(r => r.Intervals(100, 500, 1000, 1000, 1000, 1000, 1000));

        endpointConfigurator.UseEntityFrameworkOutbox<CustomersContext>(_provider);
    }
}