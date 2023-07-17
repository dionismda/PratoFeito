namespace Architecture.Infrastructure.Abstracts;

public abstract class BaseDbContext : DbContext, IUnitOfWork
{
    private readonly IMediator _mediator;
    private readonly IConfiguration _configuration;

    public string Schema { get; protected set; } = string.Empty;

    protected BaseDbContext(
        DbContextOptions options,
        IMediator mediator,
        IConfiguration configuration) : base(options)
    {
        _mediator = mediator;
        _configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasPostgresExtension("uuid-ossp");

        if (Schema != "")
            modelBuilder.HasDefaultSchema(Schema);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _configuration.GetConnectionString("PratoFeitoDb");

        optionsBuilder
            .UseNpgsql(connectionString, x =>
            {
                x.MigrationsHistoryTable("__EFMigrationsHistory", Schema);
                x.MigrationsAssembly("Monolith");
            })
            .UseSnakeCaseNamingConvention()
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
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
        if (_mediator is not null)
            await _mediator.DispatchEventsAsync(this, cancellationToken);

        var result = await base.SaveChangesAsync(cancellationToken);

        scope.Complete();

        return result;
    }

}
