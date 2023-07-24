namespace _Architecture.Infrastructure.Abstractions.DbContexts;

public abstract class IntegrationEventLogDbContext : BaseDbContext
{
    public IIntegrationEventMapper EventMapper { get; private set; }
    protected IntegrationEventLogDbContext(
        DbContextOptions options,
        IConfiguration configuration,
        IIntegrationEventMapper eventMapper) : base(options, configuration)
    {
        EventMapper = eventMapper;
    }

    public DbSet<IntegrationEventLog> IntegrationEventLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new IntegrationEventLogTypeMap());
    }
}
