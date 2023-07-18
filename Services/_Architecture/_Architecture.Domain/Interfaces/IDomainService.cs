namespace _Architecture.Domain.Interfaces;

public interface IDomainService<TAggregateRoot>
    where TAggregateRoot : AggregateRoot
{
    Task InsertAsync(TAggregateRoot entity, CancellationToken cancellationToken);
    Task UpdateAsync(TAggregateRoot entity, CancellationToken cancellationToken);
    Task DeleteAsync(Specification<TAggregateRoot> specification, CancellationToken cancellationToken);
}