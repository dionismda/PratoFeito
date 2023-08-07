namespace Restaurants.Domain.Restaurants.Interfaces;

public interface IRestaurantDomainService : IDomainService<Restaurant>
{
    Task RestaurantOperationAsync(Restaurant entity, CancellationToken cancellationToken);
}
