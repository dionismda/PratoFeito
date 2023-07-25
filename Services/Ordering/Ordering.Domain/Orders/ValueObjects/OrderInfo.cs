namespace Ordering.Domain.Orders.ValueObjects;

public class OrderInfo : ValueObject<OrderInfo>, IValidation
{
    public Identifier CustomerId { get; private set; }
    public Identifier RestaurantId { get; private set; }
    public List<OrderItem> OrderItems { get; private set; }

    public OrderInfo(Identifier customerId, Identifier restaurantId, List<OrderItem> orderItems)
    {
        CustomerId = customerId;
        RestaurantId = restaurantId;
        OrderItems = orderItems;

        Validate();
    }

    public void Validate()
    {
        OrderInfoValidator validator = new();

        var result = validator.Validate(this);

        if (!result.IsValid)
            throw new ValidationDomainException(result.GetErrors());
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return CustomerId;
        yield return RestaurantId;
        yield return OrderItems;
    }
}
