public static class Injection
{
    public static IServiceCollection InjectCustomerApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.InjectCustomerApplication(configuration);
        services.InjectCustomerDomain(configuration);
        services.InjectCustomerInfrastructure(configuration);

        return services;
    }
}