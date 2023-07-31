namespace Restaurants.Domain.Restaurants.Entities;

public sealed class Restaurant : AggregateRoot, IValidation
{
    public string Name { get; private set; } = string.Empty;
    public RestaurantMenu Menu { get; private set; } = null!;
    public RestaurantState State { get; private set; }

    private Restaurant() : base() { }

    public Restaurant(string name, RestaurantMenu menu) : this()
    {
        AddDomainEvent(new RestaurantCreatedDomainEvent(name, menu));
    }

    private void Apply(RestaurantCreatedDomainEvent @event)
    {
        Name = @event.Name;
        Menu = @event.Menu;
        State = RestaurantState.CREATED;
    }

    public void OpenRestaurant()
    {
        AddDomainEvent(new RestaurantOpenedDomainEvent());
    }

    private void Apply(RestaurantOpenedDomainEvent @event)
    {
        State = RestaurantState.OPEN;
    }

    public void CloseRestaurant()
    {
        AddDomainEvent(new RestaurantClosedDomainEvent());
    }

    private void Apply(RestaurantClosedDomainEvent @event)
    {
        State = RestaurantState.CLOSED;
    }

    public void Validate()
    {
        RestaurantValidator validator = new();

        var result = validator.Validate(this);

        if (!result.IsValid)
            throw new ValidationDomainException(result.GetErrors());
    }
}
