namespace _Architecture.Application.Interfaces;

public interface IQuery<out TResponse> : IRequest<TResponse>
{
}
