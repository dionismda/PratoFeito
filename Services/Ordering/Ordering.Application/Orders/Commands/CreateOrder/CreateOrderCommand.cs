using _Architecture.Domain.ValueObjects;

namespace Ordering.Application.Orders.Commands.CreateOrder;

public sealed class CreateOrderCommand : ICommand<Order>
{
    public OrderInfo OrderInfo { get; private set; } = null!;

    private CreateOrderCommand()
    {
    }

    public CreateOrderCommand(OrderInfo orderInfo) : this()
    {
        OrderInfo = orderInfo;
    }
}
