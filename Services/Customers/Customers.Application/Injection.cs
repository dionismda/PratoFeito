namespace Customers.Application;

public static class Injection
{
    public static IServiceCollection InjectionCustomersApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddAutoMapper(opt => { opt.AllowNullCollections = true; }, AppDomain.CurrentDomain.GetAssemblies());

        services.AddSingleton<ICustomerIntegrationEventMapper, CustomerIntegrationEventMapper>();

        services
            .InjectionCustomers()
            .InjectionCustomerOrders();

        return services;
    }

    private static IServiceCollection InjectionCustomers(this IServiceCollection services)
    {
        return services;
    }

    private static IServiceCollection InjectionCustomerOrders(this IServiceCollection services)
    {
        return services;
    }

    public static async Task<IApplicationBuilder> InjectionApplicationAsync(this IApplicationBuilder app)
    {
        var eventBus = app.ApplicationServices.GetRequiredService<ICustomerEventBusAws>();

        await eventBus.CreateTopicAsync<CustomerOrderCreatedIntegrationEvent>();

        return app;
    }
}