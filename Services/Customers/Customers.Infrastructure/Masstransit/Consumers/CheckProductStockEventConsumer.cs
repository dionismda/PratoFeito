using Customers.Infrastructure.Masstransit.Events;
using MassTransit;

namespace Customers.Infrastructure.Masstransit.Consumers;

public class CheckProductStockEventConsumer : ConsumerBase<CheckProductStockEvent>
{
    protected override Task ConsumeInternal(ConsumeContext<CheckProductStockEvent> context)
    {
        Console.WriteLine("Order process CheckProductStockEvent");

        context.RespondAsync(new
        {
            OrderId = context.Message.OrderId
        });

        return Task.CompletedTask;
    }
}