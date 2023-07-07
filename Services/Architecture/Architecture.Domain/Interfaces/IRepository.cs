namespace Architecture.Domain.Interfaces;

public interface IRepository<TAggregateRoot>
    where TAggregateRoot : AggregateRoot
{
    IUnitOfWork UnitOfWork { get; }
    Task<IList<TAggregateRoot>> GetAllAsync(
        CancellationToken cancellationToken,
        Expression<Func<TAggregateRoot, bool>>? filter = null,
        Func<IQueryable<TAggregateRoot>, IOrderedQueryable<TAggregateRoot>>? orderBy = null,
        int? top = null,
        int? skip = null,
        params string[] includeProperties);
    Task<TAggregateRoot?> GetByIdAsync(Identifier id, CancellationToken cancellationToken);
    void Insert(TAggregateRoot entity);
    void Update(TAggregateRoot entity);
    void Delete(TAggregateRoot entity);
    Task CommitAsync(CancellationToken cancellationToken);
}
