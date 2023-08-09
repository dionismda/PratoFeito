namespace Restaurants.Infrastructure.Restaurants;

public sealed class GetRestaurantByIdSpecification : Specification<Restaurant>
{
    public GetRestaurantByIdSpecification(Identifier Id) : base(restaurant => restaurant.Id == Id)
    {
    }
}

public sealed class GetRestaurantDuplicate : Specification<Restaurant>
{
    public GetRestaurantDuplicate(string name, Identifier? id) : base()
    {
        if (id is null)
            AddCriteria(restaurant => restaurant.Name == name);
        else
            AddCriteria(restaurant => restaurant.Name == name && restaurant.Id != id);
    }
}