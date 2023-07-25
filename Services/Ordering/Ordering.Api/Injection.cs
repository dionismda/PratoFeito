namespace Ordering.Api;

public static class Injection
{
    public static IServiceCollection InjectionOrderingApi(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .InjectionOrderingApplication()
            .InjectionOrderingDomain()
            .InjectionOrderingInfrastructure(configuration);
    }
}