using Customers.Infrastructure.Masstransit.Events;
using MassTransit;

namespace Customers.Infrastructure.Masstransit.Consumers;

public class OrderProcessInitializationFaultEventConsumer : ConsumerBase<Fault<OrderProcessInitializationEvent>>
{
    protected override Task ConsumeInternal(ConsumeContext<Fault<OrderProcessInitializationEvent>> context)
    {
        Console.WriteLine("Order process OrderProcessInitializationFaultEvent");

        context.RespondAsync(new
        {
            FaultId = context.Message.FaultId
        });

        return Task.CompletedTask;
    }
}