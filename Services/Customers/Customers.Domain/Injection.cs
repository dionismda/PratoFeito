namespace Customers.Domain;

public static class Injection
{
    public static IServiceCollection InjectionCustomersDomain(this IServiceCollection services)
    {
        services.AddScoped<ICustomerNotificationDomainService, CustomerNotificationDomainService>();

        return services
                .InjectionCustomers()
                .InjectionCustomerOrders();
    }

    private static IServiceCollection InjectionCustomers(this IServiceCollection services)
    {
        return services;
    }

    private static IServiceCollection InjectionCustomerOrders(this IServiceCollection services)
    {
        return services;
    }
}
