namespace _Architecture.Infrastructure.Abstracts;

public abstract class MicroserviceContext : DbContext, IUnitOfWork
{
    private readonly IMediator _mediator;
    protected MicroserviceContext(
        DbContextOptions options,
        IMediator mediator) : base(options)
    {
        _mediator = mediator;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasPostgresExtension("uuid-ossp");
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
