namespace Ordering.Domain.Orders.Entities;

public sealed class Order : AggregateRoot, IValidation
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

    public void Validate()
    {
        throw new NotImplementedException();
    }
}
