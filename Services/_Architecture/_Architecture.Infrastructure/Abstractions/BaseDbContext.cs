using MassTransit;

namespace _Architecture.Infrastructure.Abstractions;

public abstract class BaseDbContext : DbContext, IUnitOfWork
{
    private readonly IConfiguration _configuration;
    public IServiceProvider Services { get; private set; }

    public string Schema { get; protected set; } = string.Empty;

    protected BaseDbContext(
        DbContextOptions options,
        IConfiguration configuration,
        IServiceProvider services) : base(options)
    {
        _configuration = configuration;
        Services = services;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasPostgresExtension("uuid-ossp");

        if (Schema != "")
            modelBuilder.HasDefaultSchema(Schema);

        modelBuilder.AddInboxStateEntity();
        modelBuilder.AddOutboxMessageEntity();
        modelBuilder.AddOutboxStateEntity();
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

        var result = await base.SaveChangesAsync(cancellationToken);

        scope.Complete();

        return result;
    }
}
