namespace _Shared.Domain.Interfaces.Handlers;

public interface IQueryHandler<in TQuery, TQueryResult> : IHandler
    where TQuery : class, IQuery
{
    Task<TQueryResult> Handle(TQuery query, CancellationToken cancellation);
}
