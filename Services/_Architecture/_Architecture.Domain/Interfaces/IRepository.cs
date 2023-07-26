namespace _Architecture.Domain.Interfaces;

public interface IRepository<in TAggregateRoot>
    where TAggregateRoot : AggregateRoot
{
    IUnitOfWork UnitOfWork { get; }
    void Insert(TAggregateRoot entity);
    void Update(TAggregateRoot entity);
    void Delete(TAggregateRoot entity);
    Task CommitAsync(CancellationToken cancellationToken);
}
