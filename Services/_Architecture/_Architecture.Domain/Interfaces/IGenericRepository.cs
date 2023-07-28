namespace _Architecture.Domain.Interfaces;

public interface IGenericRepository<TAggregateRoot> : IRepository
    where TAggregateRoot : AggregateRoot
{
    Task<IList<TAggregateRoot>> FindAllAsync(Specification<TAggregateRoot> specification, CancellationToken cancellationToken);
    Task<TAggregateRoot?> FindByAsync(Specification<TAggregateRoot> specification, CancellationToken cancellationToken);
    void Insert(TAggregateRoot entity);
    void Update(TAggregateRoot entity);
    void Delete(TAggregateRoot entity);
}
