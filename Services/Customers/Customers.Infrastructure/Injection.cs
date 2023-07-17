namespace Customers.Infrastructure;

public static class Injection
{
    public static IServiceCollection InjectionInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMicroserviceDbContext<CustomersContext>(configuration.GetConnectionString("PratoFeitoCustomerDb"));

        services.AddDapperNpgSqlConnection();

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
