namespace _Shared.Infrastructure.Persistences;

public abstract class BaseDbContext : DbContext, IDbContextUnitOfWork
{
    private readonly IDomainMediator _mediator;

    public readonly IIntegrationEventMapper EventMapper;

    protected readonly DataBaseSetting DataBaseSettings;

    protected BaseDbContext(DbContextOptions options,
                          IOptions<DataBaseSetting> dataBaseSettings,
                          IDomainMediator mediator,
                          IIntegrationEventMapper eventMapper) : base(options)
    {
        DataBaseSettings = dataBaseSettings.Value;
        _mediator = mediator;
        EventMapper = eventMapper;
    }

    public DbSet<IntegrationEventLogEntity>? IntegrationEventLog { get; set; }
    public DbSet<ConsumerEventLogEntity>? ConsumerEventLog { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString =
            $"Server={DataBaseSettings.DefaultServer};Port=5432;Database={DataBaseSettings.DefaultDatabase};User Id={DataBaseSettings.DefaultDatabaseUser};Password={DataBaseSettings.DefaultDatabasePass};";

        optionsBuilder
            .UseNpgsql(connectionString)
            .UseSnakeCaseNamingConvention();
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("uuid-ossp");

        modelBuilder.ApplyConfiguration(new IntegrationEventLogMap());
        modelBuilder.ApplyConfiguration(new ConsumerEventLogEntityMap());

    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var changedEntity in ChangeTracker.Entries())
        {
            if (changedEntity.Entity is BaseEntity entity)
            {
                switch (changedEntity.State)
                {
                    case EntityState.Added:
                        break;
                    case EntityState.Modified:
                        entity.ModifyUpdatedDate();
                        break;
                    case EntityState.Detached:
                        break;
                    case EntityState.Unchanged:
                        break;
                    case EntityState.Deleted:
                        break;
                    default:
                        throw new InvalidEnumArgumentException("Invalid EntityState");
                }
            }
        }

        await _mediator.DispatchEventsAsync(this);

        return await base.SaveChangesAsync(cancellationToken);
    }
}
