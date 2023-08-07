namespace Ordering.Domain.Orders.Entities;

public sealed class Order : AggregateRoot
{
    public Identifier RestaurantId { get; private set; } = null!;
    public Identifier CustomerId { get; private set; } = null!;
    public OrderStateEnum State { get; private set; }

    private List<OrderItem> _orderItems = new();
    public IReadOnlyCollection<OrderItem> OrderItems
    {
        get => _orderItems.AsReadOnly();
        private set => _orderItems = value.ToList();
    }

    public Money OrderTotal => new(OrderItems.Sum(x => x.Total.Amount));

    private Order() : base() { }

    public Order(Identifier restaurantId, Identifier customerId) : this()
    {
        RestaurantId = restaurantId;
        CustomerId = customerId;
    }

    public void AddOrderItem(OrderItem orderItem)
    {
        _orderItems.Add(orderItem);
    }

    public void UpdateOrderItem(OrderItem orderItem)
    {
        _orderItems ??= new List<OrderItem>();

        if (orderItem.Id == default) return;

        var index = _orderItems.FindIndex(x => x.Id == orderItem.Id);

        if (index != -1) _orderItems[index] = orderItem;
    }

    public void RemoveOrderItem(OrderItem orderItem)
    {
        _orderItems.Remove(orderItem);
    }
}
