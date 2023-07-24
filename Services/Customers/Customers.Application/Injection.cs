namespace Customers.Application;

public static class Injection
{
    public static IServiceCollection InjectionApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        services.AddAutoMapper(opt => { opt.AllowNullCollections = true; }, AppDomain.CurrentDomain.GetAssemblies());
        services.AddScoped<ICustomerIntegrationEventMapper, CustomerIntegrationEventMapper>();

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
        return services
                .AddIntegrationEventHandler<CustomerOrderCreatedIntegrationEvent, CustomerOrderCreatedIntegrationEventHandler>();
    }

    public static async Task<IApplicationBuilder> InjectionApplicationAsync(this IApplicationBuilder app)
    {
        var eventBus = app.ApplicationServices.GetRequiredService<ICustomerEventBusAws>();

        await eventBus.CreateTopicAsync<CustomerOrderCreatedIntegrationEvent>();

        return app;
    }
}