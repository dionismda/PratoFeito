namespace Architecture.Infrastructure.Extensions;

public static class DbContextExtension
{
    public static IServiceCollection AddMicroserviceDbContext<TContext>(this IServiceCollection services, IConfiguration configuration)
        where TContext : DbContext
    {
        return services.AddDbContext<TContext>(opt =>
        {
            var connectionString = configuration.GetConnectionString("MicroserviceDb");

            opt
            .UseNpgsql(connectionString, (opt) =>
            {
                //opt.EnableRetryOnFailure(15, TimeSpan.FromSeconds(30), null);
            })
            .UseSnakeCaseNamingConvention()
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
        });
    }
}
