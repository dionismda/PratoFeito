namespace Restaurants.Domain.RestaurantOrders.Entities;

public sealed class RestaurantOrder : AggregateRoot, IValidation
{
    public Identifier RestaurantId { get; private set; } = null!;

    public RestaurantOrderState State { get; private set; }

    private List<RestaurantOrderItem> _restaurantOrderLineItem = new();
    public IReadOnlyCollection<RestaurantOrderItem> RestaurantOrderLineItem
    {
        get => _restaurantOrderLineItem.AsReadOnly();
        private set => _restaurantOrderLineItem = value.ToList();
    }

    private RestaurantOrder() : base() { }

    public RestaurantOrder(Identifier restaurantId) : this()
    {
        RestaurantId = restaurantId;
    }

    public void CreateRestaurantOrder()
    {
        AddDomainEvent(new RestaurantOrderCreatedDomainEvent(RestaurantId, RestaurantOrderLineItem));
    }

    private void Apply(RestaurantOrderCreatedDomainEvent @event)
    {
        RestaurantId = @event.RestaurantId;
        RestaurantOrderLineItem = @event.RestaurantOrderLine;
        State = RestaurantOrderState.CREATED;
    }

    public void MakeOrderAsPrepared()
    {
        AddDomainEvent(new RestaurantOrderPreparedDomainEvent());
    }

    private void Apply(RestaurantOrderPreparedDomainEvent @event)
    {
        State = RestaurantOrderState.PREPARED;
    }

    public void MakeOrderAsCanceled()
    {
        AddDomainEvent(new RestaurantOrderCanceledDomainEvent());
    }

    private void Apply(RestaurantOrderCanceledDomainEvent @event)
    {
        State = RestaurantOrderState.CANCELLED;
    }

    public void Validate()
    {
        RestaurantOrderValidator validator = new();

        var result = validator.Validate(this);

        if (!result.IsValid)
            throw new ValidationDomainException(result.GetErrors());
    }
}
