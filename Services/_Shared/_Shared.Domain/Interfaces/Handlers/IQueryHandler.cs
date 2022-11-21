namespace _Shared.Domain.Interfaces.Handlers;

public interface IQueryHandler<in TQuery> : IHandler
    where TQuery : class, IQuery
{
    Task Handle(TQuery query, CancellationToken cancellation);
}

public interface IQueryHandler<in TQuery, TQueryResult> : IHandler
    where TQuery : class, IQuery
{
    Task<TQueryResult> Handle(TQuery query, CancellationToken cancellation);
}
