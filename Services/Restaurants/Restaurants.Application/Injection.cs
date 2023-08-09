namespace Restaurants.Application;

public static class Injection
{
    public static IServiceCollection InjectionRestaurantsApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddAutoMapper(opt => { opt.AllowNullCollections = true; }, AppDomain.CurrentDomain.GetAssemblies());

        services.AddSingleton<IRestaurantIntegrationEventMapper, RestaurantIntegrationEventMapper>();

        return services;
    }
}
