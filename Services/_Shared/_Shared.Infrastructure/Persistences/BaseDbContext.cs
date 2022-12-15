namespace _Shared.Infrastructure.Persistences;

public abstract class BaseDbContext : DbContext, IDbContextUnitOfWork
{
    private readonly IDomainMediator _mediator;

    public readonly IIntegrationEventMapper EventMapper;

    private readonly DataBaseSetting _dataBaseSettings;

    protected BaseDbContext(DbContextOptions options,
                          IOptions<DataBaseSetting> dataBaseSettings,
                          IDomainMediator mediator,
                          IIntegrationEventMapper eventMapper) : base(options)
    {
        _dataBaseSettings = dataBaseSettings.Value;
        _mediator = mediator;
        EventMapper = eventMapper;
    }

    public DbSet<IntegrationEventLogEntity>? IntegrationEventLog { get; set; }
    public DbSet<ConsumerEventLogEntity>? ConsumerEventLog { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString =
            $"Server={_dataBaseSettings.DefaultServer};Port={_dataBaseSettings.DefaultPort};Database={_dataBaseSettings.DefaultDatabase};User Id={_dataBaseSettings.DefaultDatabaseUser};Password={_dataBaseSettings.DefaultDatabasePass};";

        optionsBuilder
            .UseNpgsql(connectionString)
            .UseSnakeCaseNamingConvention();
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

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
