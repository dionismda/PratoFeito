using Customers.Infrastructure.Masstransit.Events;
using MassTransit;

namespace Customers.Infrastructure.Masstransit.Consumers;

public class CheckProductStockFaultEventConsumer : ConsumerBase<Fault<CheckProductStockEvent>>
{
    protected override Task ConsumeInternal(ConsumeContext<Fault<CheckProductStockEvent>> context)
    {
        Console.WriteLine("Order process CheckProductStockFaultEvent");

        context.RespondAsync(new
        {
            FaultId = context.Message.FaultId
        });

        return Task.CompletedTask;
    }
}