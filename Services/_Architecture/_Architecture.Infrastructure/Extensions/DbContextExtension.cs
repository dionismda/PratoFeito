namespace _Architecture.Infrastructure.Extensions;

public static class DbContextExtension
{
    public static IServiceCollection AddMicroserviceDbContext<TContext>(this IServiceCollection services, string connectionString)
        where TContext : DbContext
    {
        return services.AddDbContext<TContext>(opt =>
        {
            opt
            .UseNpgsql(connectionString, x =>
            {
                x.MigrationsHistoryTable("__EFMigrationsHistory");
                x.MigrationsAssembly("Monolith");
            })
            .UseSnakeCaseNamingConvention()
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
        });
    }
}
