namespace Customers.Domain;

public static class Injection
{
    public static IServiceCollection InjectionDomain(this IServiceCollection services)
    {
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
