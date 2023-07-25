namespace Customers.Domain;

public static class Injection
{
    public static IServiceCollection InjectionCustomersDomain(this IServiceCollection services)
    {
        services.AddScoped<INotificationDomainService, NotificationDomainService>();

        return services
                .InjectionCustomers()
                .InjectionCustomerOrders();
    }

    private static IServiceCollection InjectionCustomers(this IServiceCollection services)
    {
        services.AddScoped<ICustomerDomainService, CustomerDomainService>();

        return services;
    }

    private static IServiceCollection InjectionCustomerOrders(this IServiceCollection services)
    {
        services.AddScoped<ICustomerOrderDomainService, CustomerOrderDomainService>();

        return services;
    }
}
