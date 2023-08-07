namespace Restaurants.Application._Commons.EventMappers;

public class RestaurantIntegrationEventMapper : IntegrationEventMapper, IRestaurantIntegrationEventMapper
{
    protected override IntegrationEvent? MapDomainEvent<TDomainEvent>(TDomainEvent domainEvent)
    {
        throw new NotImplementedException();
    }
}
