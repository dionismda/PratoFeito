namespace Architecture.Domain.Interfaces;

public interface IDomainService<in TAggregateRoot>
    where TAggregateRoot : AggregateRoot
{
    Task InsertAsync(TAggregateRoot entity, CancellationToken cancellationToken);
    Task UpdateAsync(TAggregateRoot entity, CancellationToken cancellationToken);
    Task DeleteAsync(Identifier id, CancellationToken cancellationToken);
}