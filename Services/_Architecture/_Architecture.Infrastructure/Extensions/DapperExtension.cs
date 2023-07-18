namespace _Architecture.Infrastructure.Extensions;

public static class DapperExtension
{
    public static IServiceCollection AddDapperNpgSqlConnection(this IServiceCollection services)
    {
        services.AddScoped<IConnectionDapper, NpgsqlDapperConnection>();

        return services;
    }
}
