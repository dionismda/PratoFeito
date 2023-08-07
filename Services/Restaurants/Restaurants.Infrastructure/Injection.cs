namespace Restaurants.Infrastructure;

public static class Injection
{
    public static IServiceCollection InjectionRestaurantsInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddQuartzJobInSeconds<RestaurantIntegrationEventLogBackgroundService>(10);
        services.AddSingleton<RestaurantEventsInterceptor>();

        services.AddDbContext<RestaurantContext>();

        services.AddDapperNpgSqlConnection();

        services.AddEventBusAwsService(configuration);

        services.AddSingleton<IRestaurantEventBusSubscriptionsManager, RestaurantEventBusSubscriptionsManager>();
        services.AddScoped<IRestaurantIntegrationEventLogService, RestaurantIntegrationEventLogService>();

        services.AddSingleton<IRestaurantEventBusAws, RestaurantEventBusAws>(sp =>
        {
            var subscribe = sp.GetRequiredService<IRestaurantEventBusSubscriptionsManager>();
            var polly = sp.GetRequiredService<IPollyPolicy>();
            var sns = sp.GetRequiredService<IAmazonSimpleNotificationService>();
            var sqs = sp.GetRequiredService<IAmazonSQS>();

            return new RestaurantEventBusAws(subscribe, polly, sns, sqs);
        });

        services
            .InjectionRestaurant()
            .InjectionRestaurantOrders();

        return services;
    }

    private static IServiceCollection InjectionRestaurant(this IServiceCollection services)
    {
        services.AddScoped<IRestaurantRepository, RestaurantRepository>();
        services.AddScoped<IRestaurantQueries, RestaurantQueries>();

        return services;
    }

    private static IServiceCollection InjectionRestaurantOrders(this IServiceCollection services)
    {
        services.AddScoped<IRestaurantOrderRepository, RestaurantOrderRepository>();

        return services;
    }
}
