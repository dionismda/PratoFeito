namespace _Architecture.Infrastructure.Abstractions;

public abstract class IntegrationEventLogContext : BaseDbContext
{
    protected IntegrationEventLogContext(
        DbContextOptions options,
        IMediator mediator,
        IConfiguration configuration) : base(options, mediator, configuration)
    {
    }

    public DbSet<IntegrationEventLog> IntegrationEventLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new IntegrationEventLogTypeMap());
    }
}
