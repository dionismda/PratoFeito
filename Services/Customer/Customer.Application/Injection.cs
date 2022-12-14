public static class Injection
{
    public static IServiceCollection InjectCustomerApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IIntegrationEventMapper, CustomerIntegrationEventMapper>();

        return services;
    }
}