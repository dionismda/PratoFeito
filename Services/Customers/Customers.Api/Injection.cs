namespace Customers.Api;

public static class Injection
{
    public static IServiceCollection InjectionCustomerApi(this IServiceCollection services, IConfiguration configuration)
    {

        return services
            .InjectionApplication()
            .InjectionDomain()
            .InjectionInfrastructure(configuration)
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