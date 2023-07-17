namespace Customers.Infrastructure._Commons;

public sealed class CustomersContext : BaseDbContext
{
    public CustomersContext(DbContextOptions options, IMediator mediator) : base(options, mediator)
    {
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