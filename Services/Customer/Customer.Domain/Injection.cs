public static class Injection
{
    public static IServiceCollection InjectCustomerDomain(this IServiceCollection services, IConfiguration configuration)
    {        
        services.AddScoped<ICustomerDomainService, CustomerDomainService>();

        services.RegisterCommandHandler<CustomerHandler, CreateCustomerCommand, CustomerEntity>();
        services.RegisterCommandHandler<CustomerHandler, CreateCustomerOrderCommand, CustomerOrderEntity>();
        services.RegisterCommandHandler<CustomerHandler, MarkCustomerOrderAsDeliveredCommand, CustomerOrderEntity>();

        return services;
    }
}