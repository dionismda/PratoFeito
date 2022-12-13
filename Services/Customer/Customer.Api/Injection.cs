public static class Injection
{
    public static IServiceCollection InjectCustomerApi(this IServiceCollection services, IConfiguration configuration)
    {        
        return services;
    }
}