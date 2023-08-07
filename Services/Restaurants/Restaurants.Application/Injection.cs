namespace Restaurants.Application;

public static class Injection
{
    public static IServiceCollection InjectionRestaurantsApplication(this IServiceCollection services)
    {
        services.AddSingleton<IRestaurantIntegrationEventMapper, RestaurantIntegrationEventMapper>();

        return services;
    }
}
