namespace _Shared.Domain.Interfaces;

public interface IDomainService<TAggregateRoot, TQueryModel>
    where TAggregateRoot : class, IAggregateRoot
    where TQueryModel : class, IQueryModel
{
    Task<List<TQueryModel>> GetAllAsync(CancellationToken cancellation, int? pageSize, int? pageNumber, IBaseParamModel? paramModel);
    Task<TAggregateRoot?> GetByIdAsync(Guid id, CancellationToken cancellation);
    Task<TAggregateRoot> InsertAsync(TAggregateRoot entity, CancellationToken cancellation, bool autoCommit = true);
    Task<TAggregateRoot> UpdateAsync(Guid id, TAggregateRoot entity, CancellationToken cancellation, bool autoCommit = true);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellation, bool autoCommit = true);
    Task CommitAsync(CancellationToken cancellation);
}
