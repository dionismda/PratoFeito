namespace _Shared.Infrastructure;

public static class Injection
{
    public static IServiceCollection InjectSharedInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IConnectionDapperManager, NpgsqlDapperConnectionManager>();

        return services;
    }
}