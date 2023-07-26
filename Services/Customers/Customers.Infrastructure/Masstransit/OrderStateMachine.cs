using Customers.Infrastructure.Masstransit.Events;
using MassTransit;

namespace Customers.Infrastructure.Masstransit;

public class OrderStateMachine : MassTransitStateMachine<OrderState>
{
    public Event<OrderProcessInitializationEvent> OrderProcessInitializationEvent { get; } = null!;
    public Event<Fault<OrderProcessInitializationEvent>> OrderProcessInitializationFaultEvent { get; } = null!;

    public Event<CheckProductStockEvent> CheckProductStockEvent { get; } = null!;
    public Event<Fault<CheckProductStockEvent>> CheckProductStockFaultEvent { get; } = null!;

    public Event<TakePaymentEvent> TakePaymentEvent { get; } = null!;
    public Event<Fault<TakePaymentEvent>> TakePaymentEventFaultEvent { get; } = null!;

    public Event<CreateOrderEvent> CreateOrderEvent { get; } = null!;
    public Event<Fault<CreateOrderEvent>> CreateOrderFaultEvent { get; } = null!;

    public Event<OrderProcessFailedEvent> OrderProcessFailedEvent { get; } = null!;

    public State OrderProcessInitializedState { get; } = null!;
    public State OrderProcessInitializedFaultedState { get; } = null!;

    public State CheckProductStockState { get; } = null!;
    public State CheckProductStockFaultedState { get; } = null!;

    public State TakePaymentState { get; } = null!;
    public State TakePaymentFaultedState { get; } = null!;

    public State CreateOrderState { get; } = null!;
    public State CreateOrderFaultedState { get; } = null!;

    public State OrderProcessFailedState { get; } = null!;

    public OrderStateMachine()
    {
        InstanceState(x => x.CurrentState);

        Event(() => OrderProcessInitializationEvent);
        Event(
            () => OrderProcessInitializationFaultEvent,
            x => x.CorrelateById(context => context.InitiatorId ?? context.Message.Message.OrderId));

        Event(() => CheckProductStockEvent);
        Event(
            () => CheckProductStockFaultEvent,
            x => x.CorrelateById(context => context.InitiatorId ?? context.Message.Message.OrderId));

        Event(() => TakePaymentEvent);
        Event(
            () => TakePaymentEventFaultEvent,
            x => x.CorrelateById(context => context.InitiatorId ?? context.Message.Message.OrderId));

        Event(() => CreateOrderEvent);
        Event(
            () => CreateOrderFaultEvent,
            x => x.CorrelateById(context => context.InitiatorId ?? context.Message.Message.OrderId));

        Event(() => OrderProcessFailedEvent);

        During(
            Initial,
            When(OrderProcessInitializationEvent)
                .Then(x => x.Saga.OrderStartDate = DateTime.Now)
                .TransitionTo(OrderProcessInitializedState));

        During(
            OrderProcessInitializedState,
            When(CheckProductStockEvent)
                .TransitionTo(CheckProductStockState));

        During(
            CheckProductStockState,
            When(TakePaymentEvent)
                .TransitionTo(TakePaymentState));

        During(
            TakePaymentState,
            When(CreateOrderEvent)
                .TransitionTo(CreateOrderState));

        DuringAny(When(CreateOrderFaultEvent)
            .TransitionTo(CreateOrderFaultedState)
            .Then(context => context.Publish<Fault<TakePaymentEvent>>(new { context.Message })));

        DuringAny(When(TakePaymentEventFaultEvent)
            .TransitionTo(TakePaymentFaultedState)
            .Then(context => context.Publish<Fault<CheckProductStockEvent>>(new { context.Message })));

        DuringAny(When(CheckProductStockFaultEvent)
            .TransitionTo(CheckProductStockFaultedState)
            .Then(context => context.Publish<Fault<OrderProcessInitializationEvent>>(new { context.Message })));

        DuringAny(When(OrderProcessInitializationFaultEvent)
            .TransitionTo(OrderProcessInitializedFaultedState)
            .Then(context => context.Publish<OrderProcessFailedEvent>(new { OrderId = context.Saga.CorrelationId })));

        DuringAny(When(OrderProcessFailedEvent)
            .TransitionTo(OrderProcessFailedState));
    }
}
