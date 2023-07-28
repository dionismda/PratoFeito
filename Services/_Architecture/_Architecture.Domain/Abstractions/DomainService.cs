namespace _Architecture.Domain.Abstractions;

public abstract class DomainService<TAggregateRoot> : IDomainService<TAggregateRoot>
    where TAggregateRoot : AggregateRoot
{
    private readonly IGenericRepository<TAggregateRoot> _repository;

    protected DomainService(IGenericRepository<TAggregateRoot> repository)
    {
        _repository = repository;
    }

    public virtual async Task InsertAsync(TAggregateRoot entity, CancellationToken cancellationToken)
    {
        _repository.Insert(entity);
        await _repository.CommitAsync(cancellationToken);
    }

    public virtual async Task UpdateAsync(TAggregateRoot entity, CancellationToken cancellationToken)
    {
        _repository.Update(entity);
        await _repository.CommitAsync(cancellationToken);
    }

    public virtual async Task DeleteAsync(TAggregateRoot entity, CancellationToken cancellationToken)
    {
        _repository.Delete(entity);
        await _repository.CommitAsync(cancellationToken);
    }
}
