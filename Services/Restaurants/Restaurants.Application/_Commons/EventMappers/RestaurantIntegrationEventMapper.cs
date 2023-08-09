namespace Restaurants.Application._Commons.EventMappers;

public class RestaurantIntegrationEventMapper : IntegrationEventMapper, IRestaurantIntegrationEventMapper
{
    protected override IntegrationEvent? MapDomainEvent<TDomainEvent>(TDomainEvent domainEvent)
    {
        return domainEvent switch
        {
            { } => null,
            _ => throw new ArgumentOutOfRangeException(nameof(domainEvent), domainEvent, null)
        };
    }
}
