namespace _Architecture.Domain.Interfaces;

public interface IRepository<TAggregateRoot>
    where TAggregateRoot : AggregateRoot
{
    IUnitOfWork UnitOfWork { get; }
    Task<IList<TAggregateRoot>> GetAllAsync(Specification<TAggregateRoot> specification, CancellationToken cancellationToken);
    Task<TAggregateRoot?> GetByIdAsync(Specification<TAggregateRoot> specification, CancellationToken cancellationToken);
    void Insert(TAggregateRoot entity);
    void Update(TAggregateRoot entity);
    void Delete(TAggregateRoot entity);
    Task CommitAsync(CancellationToken cancellationToken);
}
