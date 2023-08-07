namespace Customers.Api;

public static class Injection
{
    public static IServiceCollection InjectionCustomerApi(this IServiceCollection services, IConfiguration configuration)
    {
        return services
                .InjectionCustomers()
                .InjectionCustomerOrders()
                .InjectionCustomersApplication()
                .InjectionCustomersDomain()
                .InjectionCustomersInfrastructure(configuration);
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