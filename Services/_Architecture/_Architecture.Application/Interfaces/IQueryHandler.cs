namespace _Architecture.Application.Interfaces;

public interface IQueryHandler<in TQueryRequest, TResponse> : IRequestHandler<TQueryRequest, TResponse>
    where TQueryRequest : IQuery<TResponse>
{
}
