namespace Architecture.Domain.Interfaces;

public interface IDomainService<TAggregateRoot>
    where TAggregateRoot : AggregateRoot
{
    Task<IList<TAggregateRoot>> GetAllAsync(
        CancellationToken cancellationToken,
        Expression<Func<TAggregateRoot, bool>>? filter = null,
        Func<IQueryable<TAggregateRoot>, IOrderedQueryable<TAggregateRoot>>? orderBy = null,
        int? top = null,
        int? skip = null,
        params string[] includeProperties);
    Task<TAggregateRoot?> GetByIdAsync(Identifier id, CancellationToken cancellationToken);
    Task InsertAsync(TAggregateRoot entity, CancellationToken cancellationToken);
    Task UpdateAsync(TAggregateRoot entity, CancellationToken cancellationToken);
    Task DeleteAsync(Identifier id, CancellationToken cancellationToken);
}