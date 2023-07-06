namespace Architecture.Application.Abstracts;

public abstract class QueryHandler<TAggregateRoot, TQueryRequest, TResponse> : IQueryHandler<TQueryRequest, TResponse>
    where TQueryRequest : IQuery<TResponse>
    where TAggregateRoot : AggregateRoot
{
    protected IRepository<TAggregateRoot> Repository { get; private set; }

    protected QueryHandler(IRepository<TAggregateRoot> repository)
    {
        Repository = repository;
    }

    public abstract Task<TResponse> Handle(TQueryRequest request, CancellationToken cancellationToken);
}
