using Customers.Infrastructure.Masstransit.Dtos;
using Customers.Infrastructure.Masstransit.Events;
using MassTransit;

namespace Customers.Infrastructure.Masstransit.Consumers;

public class OrderProcessInitializationEventConsumer : ConsumerBase<OrderProcessInitializationEvent>
{
    protected override Task ConsumeInternal(ConsumeContext<OrderProcessInitializationEvent> context)
    {
        Console.WriteLine("Order process Initialized");

        context.RespondAsync(new OrderProcessInitiazationDto
        {
            OrderId = context.Message.OrderId
        });

        return Task.CompletedTask;
    }
}