namespace _Architecture.Infrastructure.Abstracts;

public abstract class Repository<TAggregateRoot> : IRepository<TAggregateRoot>
    where TAggregateRoot : AggregateRoot
{
    private readonly MicroserviceContext _context;

    public IUnitOfWork UnitOfWork => _context;

    protected Repository(MicroserviceContext context)
    {
        _context = context;
    }

    public virtual async Task<IList<TAggregateRoot>> GetAllAsync(
        CancellationToken cancellationToken,
        Expression<Func<TAggregateRoot, bool>>? filter = null,
        Func<IQueryable<TAggregateRoot>, IOrderedQueryable<TAggregateRoot>>? orderBy = null,
        int? top = null,
        int? skip = null,
        params string[] includeProperties)
    {
        IQueryable<TAggregateRoot> query = _context.Set<TAggregateRoot>();

        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (includeProperties.Length > 0)
        {
            query = includeProperties.Aggregate(query, (theQuery, theInclude) => theQuery.Include(theInclude)).AsSplitQuery();
        }

        if (orderBy != null)
        {
            query = orderBy(query);
        }

        if (skip.HasValue)
        {
            query = query.Skip(skip.Value);
        }

        if (top.HasValue)
        {
            query = query.Take(top.Value);
        }

        return await query.ToListAsync(cancellationToken);
    }

    public virtual async Task<TAggregateRoot?> GetByIdAsync(Identifier id, CancellationToken cancellationToken)
    {
        return await _context.Set<TAggregateRoot>().FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
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
