namespace Architecture.Domain.Abstracts;

public abstract class DomainService<TAggregateRoot> : IDomainService<TAggregateRoot>
    where TAggregateRoot : AggregateRoot
{
    protected IRepository<TAggregateRoot> Repository { get; private set; }

    protected DomainService(IRepository<TAggregateRoot> repository)
    {
        Repository = repository;
    }

    public virtual async Task<IList<TAggregateRoot>> GetAllAsync(
        CancellationToken cancellationToken,
        Expression<Func<TAggregateRoot, bool>>? filter = null,
        Func<IQueryable<TAggregateRoot>, IOrderedQueryable<TAggregateRoot>>? orderBy = null,
        int? top = null,
        int? skip = null,
        params string[] includeProperties)
    {
        return await Repository.GetAllAsync(cancellationToken, filter, orderBy, top, skip, includeProperties);
    }

    public virtual async Task<TAggregateRoot?> GetByIdAsync(Identifier id, CancellationToken cancellationToken)
    {
        return await Repository.GetByIdAsync(id, cancellationToken);
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
