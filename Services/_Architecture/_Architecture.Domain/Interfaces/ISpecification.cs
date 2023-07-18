namespace _Architecture.Domain.Interfaces;

public interface ISpecification<TAggregateRoot>
    where TAggregateRoot : AggregateRoot
{
    Expression<Func<TAggregateRoot, bool>>? Criteria { get; }
    List<Expression<Func<TAggregateRoot, object>>> IncludeExpressions { get; }
    Expression<Func<TAggregateRoot, object>>? OrderByExpression { get; }
    Expression<Func<TAggregateRoot, object>>? OrderByDescendingExpression { get; }
    void AddInclude(Expression<Func<TAggregateRoot, object>> includeExpression);
    void AddOrderBy(Expression<Func<TAggregateRoot, object>> orderByExpressions);
    void AddOrderByDescending(Expression<Func<TAggregateRoot, object>> orderByDescendingExpressions);
}
