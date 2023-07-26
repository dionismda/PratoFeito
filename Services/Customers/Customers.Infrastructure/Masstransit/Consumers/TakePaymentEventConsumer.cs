using Customers.Infrastructure.Masstransit.Events;
using MassTransit;

namespace Customers.Infrastructure.Masstransit.Consumers;

public class TakePaymentEventConsumer : ConsumerBase<TakePaymentEvent>
{
    protected override Task ConsumeInternal(ConsumeContext<TakePaymentEvent> context)
    {
        Console.WriteLine("Order process TakePaymentEvent");

        context.RespondAsync(new
        {
            OrderId = context.Message.OrderId
        });

        return Task.CompletedTask;
    }
}