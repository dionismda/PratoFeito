namespace _Shared.Infrastructure.Persistences;

public abstract class BaseDbContext : DbContext, IDbContext
{
    private readonly IDomainMediator _mediator;

    private readonly DataBaseSetting _dataBaseSettings;

    public readonly IIntegrationEventMapper EventMapper;

    public Guid TenantId { get; protected set; }
    public string Server { get; protected set; } = "";
    public string Port { get; protected set; } = "";
    public string DbAlias { get; protected set; } = "";
    public string DbUser { get; protected set; } = "";
    public string DbPass { get; protected set; } = "";

    protected BaseDbContext(DbContextOptions options,
                            IOptions<DataBaseSetting> dataBaseSettings,
                            IDomainMediator mediator,
                            IIntegrationEventMapper eventMapper,
                            IDbContextConfig dbContextConfig) : base(options)
    {
        _dataBaseSettings = dataBaseSettings.Value;
        _mediator = mediator;
        EventMapper = eventMapper;

        ContextSetData(dbContextConfig);
    }


    public DbSet<IntegrationEventLogEntity>? IntegrationEventLog { get; set; }
    public DbSet<ConsumerEventLogEntity>? ConsumerEventLog { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString =
            $"Server={Server};Port={Port};Database={DbAlias};User Id={DbUser};Password={DbPass};";

        optionsBuilder
            .UseNpgsql(connectionString)
            .UseSnakeCaseNamingConvention();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasPostgresExtension("uuid-ossp");

        modelBuilder.ApplyConfiguration(new IntegrationEventLogMap(TenantId));
        modelBuilder.ApplyConfiguration(new ConsumerEventLogEntityMap(TenantId));
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var changedEntity in ChangeTracker.Entries<BaseEntity>())
        {
            if (changedEntity.Entity is BaseEntity entity)
            {
                switch (changedEntity.State)
                {
                    case EntityState.Added:
                        changedEntity.Entity.TenantId = TenantId;
                        break;
                    case EntityState.Modified:
                        changedEntity.Entity.TenantId = TenantId;
                        entity.ModifyUpdatedDate();
                        break;
                    case EntityState.Deleted:
                        changedEntity.Entity.TenantId = TenantId;
                        break;
                    default:
                        throw new InvalidEnumArgumentException("Invalid EntityState");
                }
            }
        }

        await _mediator.DispatchEventsAsync(this);

        return await base.SaveChangesAsync(cancellationToken);
    }

    public void SetConfig(string server, string port, string dbAlias, string dbUser, string dbPass, Guid tenantId)
    {
        TenantId = tenantId;
        Server = server;
        Port = port;
        DbAlias = dbAlias;
        DbUser = dbUser;
        DbPass = dbPass;
    }

    protected virtual void ContextSetData(IDbContextConfig dbContextConfig)
    {
        DbAlias = _dataBaseSettings.DefaultDatabase;

        DbUser = _dataBaseSettings.DefaultDatabaseUser;

        DbPass = _dataBaseSettings.DefaultDatabasePass;

        Server = _dataBaseSettings.DefaultServer;

        TenantId = dbContextConfig.TenantId;
    }
}
