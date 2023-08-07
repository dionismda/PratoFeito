namespace Customers.Infrastructure._Commons.Persistences;

public sealed class CustomersContext : BaseDbContext
{
    public CustomersContext(
        DbContextOptions<CustomersContext> options,
        IConfiguration configuration,
        IServiceProvider service) : base(options, configuration, service)
    {
        Schema = nameof(ContextEnum.Customers).ToLower();
    }

    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<CustomerOrder> CustomerOrders { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = Configuration.GetConnectionString("PratoFeitoDb");
        var interceptor = Services.GetRequiredService<CustomerEventsInterceptor>();

        optionsBuilder
            .UseNpgsql(connectionString, x =>
            {
                x.MigrationsHistoryTable("__EFMigrationsHistory", Schema);
                x.MigrationsAssembly("Monolith");
            })
            .UseSnakeCaseNamingConvention()
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors()
            .AddInterceptors(interceptor);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new CustomerTypeMap());
        modelBuilder.ApplyConfiguration(new CustomerOrderTypeMap());
    }
}