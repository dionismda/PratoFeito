namespace Customers.Infrastructure;

public static class Injection
{
    public static IServiceCollection InjectionInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CustomersContext>();

        services.AddDapperNpgSqlConnection();

        services.AddEventBusAwsService(configuration);

        services.AddSingleton<ICustomerEventBusSubscriptionsManager, CustomerEventBusSubscriptionsManager>();

        services.AddSingleton<ICustomerEventBusAws, CustomerEventBusAws>(sp =>
        {
            var subscribe = sp.GetRequiredService<ICustomerEventBusSubscriptionsManager>();
            var polly = sp.GetRequiredService<IPollyPolicy>();
            var sns = sp.GetRequiredService<IAmazonSimpleNotificationService>();
            var sqs = sp.GetRequiredService<IAmazonSQS>();

            return new CustomerEventBusAws(subscribe, polly, sns, sqs);
        });

        services
            .InjectionCustomers()
            .InjectionCustomerOrders();

        return services;
    }

    private static IServiceCollection InjectionCustomers(this IServiceCollection services)
    {
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<ICustomerQueries, CustomerQueries>();

        return services;
    }

    private static IServiceCollection InjectionCustomerOrders(this IServiceCollection services)
    {
        services.AddScoped<ICustomerOrderRepository, CustomerOrderRepository>();

        return services;
    }
}
