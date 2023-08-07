namespace Restaurants.Domain;

public static class Injection
{
    public static IServiceCollection InjectionRestaurantsDomain(this IServiceCollection services)
    {
        services.AddScoped<IRestaurantNotificationDomainService, RestaurantNotificationDomainService>();

        services.InjectionRestaurant();

        return services;
    }

    private static IServiceCollection InjectionRestaurant(this IServiceCollection services)
    {
        return services;
    }

}