namespace _Shared.Domain.Interfaces;

public interface IRepository<TAggregateRoot, TQueryModel>
    where TAggregateRoot : class, IAggregateRoot
    where TQueryModel : class, IQueryModel
{
    IDbContextUnitOfWork UnitOfWork { get; }
    Task<List<TQueryModel>> GetAllAsync(CancellationToken cancellation, int? pageSize, int? pageNumber, IBaseParamModel? paramModel);
    Task<TAggregateRoot?> GetByIdAsync(Guid id, CancellationToken cancellation);    
    Task<TAggregateRoot> InsertAsync(TAggregateRoot entity, CancellationToken cancellation);
    Task<TAggregateRoot> UpdateAsync(Guid id, TAggregateRoot entity, CancellationToken cancellation);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellation);
    Task CommitAsync(CancellationToken cancellation);

    //Task<TAggregateRoot?> GetByIdNoTrackingAsync(Guid id);

    //void Detach(TAggregateRoot entity);
}
