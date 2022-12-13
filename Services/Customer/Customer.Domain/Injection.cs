public static class Injection
{
    public static IServiceCollection InjectCustomerInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICustomerDomainService, CustomerDomainService>();

        return services;
    }
}