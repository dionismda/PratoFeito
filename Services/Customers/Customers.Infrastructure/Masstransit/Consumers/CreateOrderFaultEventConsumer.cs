using Customers.Infrastructure.Masstransit.Events;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customers.Infrastructure.Masstransit.Consumers;

public class CreateOrderFaultEventConsumer : ConsumerBase<Fault<CreateOrderEvent>>
{
    protected override Task ConsumeInternal(ConsumeContext<Fault<CreateOrderEvent>> context)
    {
        Console.WriteLine("Order process CreateOrderFaultEvent");

        context.RespondAsync(new
        {
            FaultId = context.Message.FaultId
        });

        return Task.CompletedTask;
    }
}