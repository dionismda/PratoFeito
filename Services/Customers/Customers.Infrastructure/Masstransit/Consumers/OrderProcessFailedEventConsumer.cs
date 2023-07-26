using Customers.Infrastructure.Masstransit.Events;
using MassTransit;

namespace Customers.Infrastructure.Masstransit.Consumers;

public class OrderProcessFailedEventConsumer : ConsumerBase<OrderProcessFailedEvent>
{
    protected override Task ConsumeInternal(ConsumeContext<OrderProcessFailedEvent> context)
    {
        Console.WriteLine("Order process OrderProcessFailedEvent");

        context.RespondAsync(new
        {
            OrderId = context.Message.OrderId
        });

        return Task.CompletedTask;
    }
}