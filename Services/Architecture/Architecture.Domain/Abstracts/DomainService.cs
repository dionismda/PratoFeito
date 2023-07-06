namespace Architecture.Domain.Abstracts;

public abstract class DomainService<TAggregateRoot> : IDomainService<TAggregateRoot>
    where TAggregateRoot : AggregateRoot
{
    protected IRepository<TAggregateRoot> Repository { get; private set; }

    protected DomainService(IRepository<TAggregateRoot> repository)
    {
        Repository = repository;
    }

    public virtual async Task InsertAsync(TAggregateRoot entity, CancellationToken cancellationToken)
    {
        Repository.Insert(entity);
        await Repository.CommitAsync(cancellationToken);
    }

    public virtual async Task UpdateAsync(TAggregateRoot entity, CancellationToken cancellationToken)
    {
        Repository.Update(entity);
        await Repository.CommitAsync(cancellationToken);
    }

    public virtual async Task DeleteAsync(Identifier id, CancellationToken cancellationToken)
    {
        var entity = await Repository.GetByIdAsync(id, cancellationToken) ?? throw new NotFoundException();
        Repository.Delete(entity);
        await Repository.CommitAsync(cancellationToken);
    }
}
