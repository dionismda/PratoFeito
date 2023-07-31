namespace _Shared.ValueObjects.Restaurants;

public sealed class RestaurantOrderDetails : ValueObject<RestaurantOrderDetails>
{
    public List<RestaurantOrderLineItem> OrderLineItems { get; private set; }

    public RestaurantOrderDetails(List<RestaurantOrderLineItem> orderLineItems)
    {
        OrderLineItems = orderLineItems;
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return OrderLineItems;
    }
}
