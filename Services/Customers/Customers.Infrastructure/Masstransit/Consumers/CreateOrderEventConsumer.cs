using Customers.Infrastructure.Masstransit.Events;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customers.Infrastructure.Masstransit.Consumers;

public class CreateOrderEventConsumer : ConsumerBase<CreateOrderEvent>
{
    protected override Task ConsumeInternal(ConsumeContext<CreateOrderEvent> context)
    {
        Console.WriteLine("Order process CreateOrderEvent");

        context.RespondAsync(new
        {
            OrderId = context.Message.OrderId
        });

        return Task.CompletedTask;
    }
}