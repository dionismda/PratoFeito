namespace _Architecture.Infrastructure.Abstractions.DbContexts;

public abstract class ApplicationDbContext : BaseDbContext, IUnitOfWork
{
    private readonly IMediator _mediator;
    public IntegrationEventLogDbContext? EventLogContext { get; private set; }

    protected ApplicationDbContext(
        DbContextOptions options,
        IConfiguration configuration,
        IMediator mediator,
        IntegrationEventLogDbContext? eventLogContext) : base(options, configuration)
    {
        _mediator = mediator;
        EventLogContext = eventLogContext;
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
