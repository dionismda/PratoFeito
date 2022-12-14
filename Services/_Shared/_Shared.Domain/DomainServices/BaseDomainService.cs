namespace _Shared.Domain.DomainServices;

public abstract class BaseDomainService<TAggregateRoot, TQueryModel> : IDomainService<TAggregateRoot, TQueryModel>
    where TAggregateRoot : class, IAggregateRoot
    where TQueryModel : class, IQueryModel
{

    protected readonly IRepository<TAggregateRoot, TQueryModel> Repository;

    protected BaseDomainService(IRepository<TAggregateRoot, TQueryModel> repository)
    {
        Repository = repository;
    }

    public virtual async Task<List<TQueryModel>> GetAllAsync(CancellationToken cancellation, int? pageSize, int? pageNumber, IBaseParamModel? paramModel)
    {
        return await Repository.GetAllAsync(cancellation, pageSize, pageNumber, paramModel);
    }

    public virtual async Task<TAggregateRoot?> GetByIdAsync(Guid id, CancellationToken cancellation)
    {
        return await Repository.GetByIdAsync(id, cancellation);
    }

    public virtual async Task<TAggregateRoot> InsertAsync(TAggregateRoot entity, CancellationToken cancellation, bool autoCommit = true)
    {
        var result = await Repository.InsertAsync(entity, cancellation);

        if (autoCommit) await CommitAsync(cancellation);

        return result;
    }

    public virtual async Task<TAggregateRoot> UpdateAsync(Guid id, TAggregateRoot entity, CancellationToken cancellation, bool autoCommit = true)
    {
        var result = await Repository.UpdateAsync(id, entity, cancellation);

        if (autoCommit) await CommitAsync(cancellation);

        return result;
    }

    public virtual async Task<bool> DeleteAsync(Guid id, CancellationToken cancellation, bool autoCommit = true)
    {
        var result = await Repository.DeleteAsync(id, cancellation);

        if (autoCommit) await CommitAsync(cancellation);

        return result;
    }

    public virtual async Task CommitAsync(CancellationToken cancellation)
    {
        await Repository.UnitOfWork.SaveChangesAsync();
    }
}
