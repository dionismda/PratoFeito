namespace _Architecture.Infrastructure.Extensions;

public static class QueryableExtension
{
    public static IQueryable<TAggregateRoot> GetQuery<TAggregateRoot>(
        IQueryable<TAggregateRoot> inputQueryable,
        Specification<TAggregateRoot> specification)
        where TAggregateRoot : AggregateRoot
    {
        var query = inputQueryable;

        if (specification.Criteria is not null)
        {
            query = query.Where(specification.Criteria);
        }

        query = specification.IncludeExpressions.Aggregate(query, (current, include) => current.Include(include));

        if (specification.OrderByExpression is not null)
        {
            query = query.OrderBy(specification.OrderByExpression);
        }
        else if (specification.OrderByDescendingExpression is not null)
        {
            query = query.OrderByDescending(specification.OrderByDescendingExpression);
        }

        if (specification.IsSplitQuery)
        {
            query.AsSingleQuery();
        }

        return query;
    }
}
