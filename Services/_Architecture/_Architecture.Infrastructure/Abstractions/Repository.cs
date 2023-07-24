namespace _Architecture.Infrastructure.Abstractions;

public abstract class Repository<TAggregateRoot> : IRepository<TAggregateRoot>
    where TAggregateRoot : AggregateRoot
{
    private readonly BaseDbContext _context;

    public IUnitOfWork UnitOfWork => _context;

    protected Repository(BaseDbContext context)
    {
        _context = context;
    }

    private IQueryable<TAggregateRoot> ApplySpecification(Specification<TAggregateRoot> specification)
    {
        return QueryableExtension.GetQuery(_context.Set<TAggregateRoot>(), specification);
    }

    public async virtual Task<IList<TAggregateRoot>> GetAllAsync(Specification<TAggregateRoot> specification, CancellationToken cancellationToken)
    {
        return await ApplySpecification(specification).ToListAsync(cancellationToken);
    }

    public async virtual Task<TAggregateRoot?> GetByIdAsync(Specification<TAggregateRoot> specification, CancellationToken cancellationToken)
    {
        return await ApplySpecification(specification).FirstOrDefaultAsync(cancellationToken);
    }

    public virtual void Insert(TAggregateRoot entity)
    {
        _context.Set<TAggregateRoot>().Add(entity);
    }

    public virtual void Update(TAggregateRoot entity)
    {
        _context.Set<TAggregateRoot>().Update(entity);
    }

    public virtual void Delete(TAggregateRoot entity)
    {
        _context.Set<TAggregateRoot>().Remove(entity);
    }

    public virtual async Task CommitAsync(CancellationToken cancellationToken)
    {
        await UnitOfWork.SaveChangesAsync(cancellationToken);
    }
}
