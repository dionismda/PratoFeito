public static class Injection
{
    public static IServiceCollection InjectCustomerApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IIntegrationEventMapper, CustomerIntegrationEventMapper>();
        services.AddScoped<ICommandDispatcher, CommandDispatcher>();
        services.AddScoped<IQueryDispatcher, QueryDispatcher>();

        return services;
    }
}