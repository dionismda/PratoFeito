using MassTransit;

namespace Customers.Infrastructure.Masstransit;

public class OrderState : SagaStateMachineInstance, ISagaVersion
{
    public Guid CorrelationId { get; set; }
    public string? CurrentState { get; set; }
    public DateTime OrderStartDate { get; set; }
    public int Version { get; set; }
}