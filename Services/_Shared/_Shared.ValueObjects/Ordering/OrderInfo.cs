using _Shared.ValueObjects._Commons;
using _Shared.ValueObjects.Abstractions;

namespace _Shared.ValueObjects.Ordering;

public class OrderInfo : ValueObject<OrderInfo>
{
    public Identifier CustomerId { get; private set; }
    public Identifier RestaurantId { get; private set; }
    public List<OrderItemInfo> OrderItemInfos { get; private set; }

    public OrderInfo(Identifier customerId, Identifier restaurantId, List<OrderItemInfo> orderItemInfos)
    {
        CustomerId = customerId;
        RestaurantId = restaurantId;
        OrderItemInfos = orderItemInfos;
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return CustomerId;
        yield return RestaurantId;
        yield return OrderItemInfos;
    }
}
