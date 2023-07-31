namespace _Shared.ValueObjects.Ordering;

public sealed class OrderDetails : OrderInfo
{
    public Money OrderTotal { get; private set; }

    public OrderDetails(
        Money orderTotal,
        Identifier customerId,
        Identifier restaurantId,
        List<OrderItemInfo> orderItemInfos) : base(customerId, restaurantId, orderItemInfos)
    {
        OrderTotal = orderTotal;
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return CustomerId;
        yield return RestaurantId;
        yield return OrderItemInfos;
        yield return OrderTotal;
    }
}
