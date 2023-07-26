using Customers.Infrastructure.Masstransit.Events;
using MassTransit;

namespace Customers.Infrastructure.Masstransit.Consumers;

public class TakePaymentFaultEventConsumer : ConsumerBase<Fault<TakePaymentEvent>>
{
    protected override Task ConsumeInternal(ConsumeContext<Fault<TakePaymentEvent>> context)
    {
        Console.WriteLine("Order process TakePaymentFaultEvent");

        context.RespondAsync(new
        {
            FaultId = context.Message.FaultId
        });

        return Task.CompletedTask;
    }
}