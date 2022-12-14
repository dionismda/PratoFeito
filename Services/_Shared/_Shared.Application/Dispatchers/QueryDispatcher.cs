namespace _Shared.Application.Dispatchers;

public class QueryDispatcher : IQueryDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public QueryDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task<TResultQuery> Handle<TQuery, TResultQuery>(TQuery query, CancellationToken cancellationToken)
        where TQuery : class, IQuery
    {
        if (_serviceProvider.GetService(typeof(IQueryHandler<TQuery, TResultQuery>)) is not IQueryHandler<TQuery, TResultQuery> service)
            throw new InvalidCastException("Could not find QueryHandler injection");

        return await service.Handle((dynamic)query, cancellationToken);
    }
}
