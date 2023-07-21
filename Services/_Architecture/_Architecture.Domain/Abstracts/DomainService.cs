namespace _Architecture.Domain.Abstracts;

public abstract class DomainService<TAggregateRoot> : IDomainService<TAggregateRoot>
    where TAggregateRoot : AggregateRoot
{
    private readonly IRepository<TAggregateRoot> _repository;

    protected DomainService(IRepository<TAggregateRoot> repository)
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

    public virtual async Task DeleteAsync(Specification<TAggregateRoot> specification, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(specification, cancellationToken) ?? throw new NotFoundException();
        _repository.Delete(entity);
        await _repository.CommitAsync(cancellationToken);
    }
}
