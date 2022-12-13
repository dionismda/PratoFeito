public static class Injection
{
    public static IServiceCollection InjectCustomerInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ICustomerDbContext, CustomerDbContext>();

        services.AddSingleton<IConnectionDapperManager, NpgsqlDapperConnectionManager>();

        services.AddScoped<ICustomerRepository, CustomerRepositoty>();
        services.AddScoped<IDomainMediator, MediaTrMediator>();

        var dataBaseSetting = configuration.GetSection(nameof(DataBaseSetting));
        services.Configure<DataBaseSetting>(options =>
        {
            options.DefaultServer = dataBaseSetting[nameof(DataBaseSetting.DefaultServer)];
            options.DefaultPort = dataBaseSetting[nameof(DataBaseSetting.DefaultPort)];
            options.DefaultDatabase = dataBaseSetting[nameof(DataBaseSetting.DefaultDatabase)];
            options.DefaultDatabaseUser = dataBaseSetting[nameof(DataBaseSetting.DefaultDatabaseUser)];
            options.DefaultDatabasePass = dataBaseSetting[nameof(DataBaseSetting.DefaultDatabasePass)];
        });        

        return services;
    }
}