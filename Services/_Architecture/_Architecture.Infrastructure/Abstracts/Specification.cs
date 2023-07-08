namespace _Architecture.Infrastructure.Abstracts;

public abstract class Specification<TEntity>
    where TEntity : Entity
{
    public bool IsSplitQuery { get; protected set; }
    public Expression<Func<TEntity, bool>>? Criteria { get; }
    public List<Expression<Func<TEntity, object>>> IncludeExpressions { get; } = new();
    public Expression<Func<TEntity, object>>? OrderByExpression { get; private set; }
    public Expression<Func<TEntity, object>>? OrderByDescendingExpression { get; private set; }

    protected Specification(Expression<Func<TEntity, bool>>? criteria)
    {
        Criteria = criteria;
    }

    protected void AddInclude(Expression<Func<TEntity, object>> includeExpression)
    {
        IncludeExpressions.Add(includeExpression);
    }

    protected void AddOrderBy(Expression<Func<TEntity, object>> orderByExpressions)
    {
        OrderByExpression = orderByExpressions;
    }

    protected void AddOrderByDescending(Expression<Func<TEntity, object>> orderByDescendingExpressions)
    {
        OrderByDescendingExpression = orderByDescendingExpressions;
    }
}
