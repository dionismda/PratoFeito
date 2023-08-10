namespace _Architecture.Infrastructure.Abstractions;

public abstract class BaseDbContext : DbContext, IUnitOfWork
{
    protected IConfiguration Configuration { get; private set; }
    public IServiceProvider Services { get; private set; }

    public string Schema { get; protected set; } = string.Empty;

    protected BaseDbContext(
        DbContextOptions options,
        IConfiguration configuration,
        IServiceProvider services) : base(options)
    {
        Configuration = configuration;
        Services = services;
    }

    public DbSet<IntegrationEventLog> IntegrationEventLogs { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasPostgresExtension("uuid-ossp");

        if (Schema != "")
            modelBuilder.HasDefaultSchema(Schema);

        modelBuilder.ApplyConfiguration(new IntegrationEventLogTypeMap());
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var changedEntity in ChangeTracker.Entries())
        {
            if (changedEntity.Entity is Entity entity)
            {
                switch (changedEntity.State)
                {
                    case EntityState.Modified:
                        entity.ModifyUpdatedDate();
                        break;
                }
            }
        }

        using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

        var result = await base.SaveChangesAsync(cancellationToken);

        scope.Complete();

        return result;
    }
}
