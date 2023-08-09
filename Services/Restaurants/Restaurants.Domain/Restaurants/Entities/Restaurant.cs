namespace Restaurants.Domain.Restaurants.Entities;

public sealed class Restaurant : AggregateRoot
{
    public string Name { get; private set; } = string.Empty;
    public RestaurantState State { get; private set; }

    private Restaurant() : base() { }

    public Restaurant(string name) : this()
    {
        AddDomainEvent(new RestaurantCreatedDomainEvent(name));
    }

    private void Apply(RestaurantCreatedDomainEvent @event)
    {
        Name = @event.Name;
        State = RestaurantState.Created;
    }

    public void OpenRestaurant()
    {
        if (State != RestaurantState.Opened)
        {
            AddDomainEvent(new RestaurantOpenedDomainEvent(Id));
        }
        else
        {
            throw new RestaurantWasOpenedException(Id);
        }
    }

    private void Apply(RestaurantOpenedDomainEvent @event)
    {
        State = RestaurantState.Opened;
    }

    public void CloseRestaurant()
    {
        if (State == RestaurantState.Opened)
        {
            AddDomainEvent(new RestaurantClosedDomainEvent(Id));
        }
        else
        {
            throw new RestaurantStateNotOpenedException();
        }
    }

    private void Apply(RestaurantClosedDomainEvent @event)
    {
        State = RestaurantState.Closed;
    }

    public void ChangeName(string name)
    {
        AddDomainEvent(new RestaurantChangeNameDomainEvent(name));
    }

    private void Apply(RestaurantChangeNameDomainEvent @event)
    {
        Name = @event.RestaurantName;
    }
}
