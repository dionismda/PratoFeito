namespace _Architecture.Domain.Abstractions;

public abstract class Specification<TAggregateRoot> : ISpecification<TAggregateRoot>
    where TAggregateRoot : AggregateRoot
{
    public bool IsSplitQuery { get; protected set; }
    public Expression<Func<TAggregateRoot, bool>>? Criteria { get; }
    public List<Expression<Func<TAggregateRoot, object>>> IncludeExpressions { get; } = new();
    public Expression<Func<TAggregateRoot, object>>? OrderByExpression { get; private set; }
    public Expression<Func<TAggregateRoot, object>>? OrderByDescendingExpression { get; private set; }

    protected Specification(Expression<Func<TAggregateRoot, bool>>? criteria)
    {
        Criteria = criteria;
    }

    public void AddInclude(Expression<Func<TAggregateRoot, object>> includeExpression)
    {
        IncludeExpressions.Add(includeExpression);
    }

    public void AddOrderBy(Expression<Func<TAggregateRoot, object>> orderByExpressions)
    {
        OrderByExpression = orderByExpressions;
    }

    public void AddOrderByDescending(Expression<Func<TAggregateRoot, object>> orderByDescendingExpressions)
    {
        OrderByDescendingExpression = orderByDescendingExpressions;
    }
}
