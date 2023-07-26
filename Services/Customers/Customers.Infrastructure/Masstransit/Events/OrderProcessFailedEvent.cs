﻿using MassTransit;
using System.Runtime.CompilerServices;

namespace Customers.Infrastructure.Masstransit.Events;

public class OrderProcessFailedEvent
{
    public Guid OrderId { get; set; }

#pragma warning disable CA2255 // The 'ModuleInitializer' attribute should not be used in libraries
    [ModuleInitializer]
#pragma warning restore CA2255 // The 'ModuleInitializer' attribute should not be used in libraries
    internal static void Init()
    {
        GlobalTopology.Send.UseCorrelationId<OrderProcessFailedEvent>(x => x.OrderId);
    }
}