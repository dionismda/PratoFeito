public static class Injection
{
    public static IServiceCollection InjectCustomerInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        var dataBaseSetting = configuration.GetSection(nameof(DataBaseSetting));

        services.Configure<DataBaseSetting>(options =>
        {
            options.DefaultServer = dataBaseSetting[nameof(DataBaseSetting.DefaultServer)];
            options.DefaultPort = dataBaseSetting[nameof(DataBaseSetting.DefaultPort)];
            options.DefaultDatabase = dataBaseSetting[nameof(DataBaseSetting.DefaultDatabase)];
            options.DefaultDatabaseUser = dataBaseSetting[nameof(DataBaseSetting.DefaultDatabaseUser)];
            options.DefaultDatabasePass = dataBaseSetting[nameof(DataBaseSetting.DefaultDatabasePass)];
        });

        services.AddDbContext<CustomerDbContext>();

        services.AddSingleton<IConnectionDapperManager, NpgsqlDapperConnectionManager>();

        services.AddScoped<ICustomerRepository, CustomerRepositoty>();
        services.AddScoped<IDomainMediator, MediaTrMediator>();   

        return services;
    }
}