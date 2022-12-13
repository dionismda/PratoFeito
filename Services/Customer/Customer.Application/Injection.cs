public static class Injection
{
    public static IServiceCollection InjectCustomerApplication(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}