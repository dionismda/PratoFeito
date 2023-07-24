namespace Customers.Infrastructure._Commons.Persistences;

public sealed class CustomersContext : ApplicationDbContext
{
    public CustomersContext(
        DbContextOptions<CustomersContext> options,
        IMediator mediator,
        IConfiguration configuration,
        CustomerIntegrationEventLogContext eventLogContext) : base(options, configuration, mediator, eventLogContext)
    {
        Schema = nameof(ContextEnum.Customers).ToLower();
    }

    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<CustomerOrder> CustomerOrders { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new CustomerTypeMap());
        modelBuilder.ApplyConfiguration(new CustomerOrderTypeMap());
    }
}