namespace Restaurants.Api;

public static class Injection
{
    public static IServiceCollection InjectionRestaurantApi(this IServiceCollection services, IConfiguration configuration)
    {

        services.InjectionRestaurantApplication()
                .InjectionRestaurantDomain()
                .InjectionRestaurantInfrastructure(configuration);

        return services;
    }
}
