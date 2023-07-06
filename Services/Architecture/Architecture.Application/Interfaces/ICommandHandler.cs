namespace Architecture.Application.Interfaces;

public interface ICommandHandler<in TCommandRequest, TResponse> : IRequestHandler<TCommandRequest, TResponse>
    where TCommandRequest : ICommand<TResponse>
{
}

public interface ICommandHandler<in TCommandRequest> : IRequestHandler<TCommandRequest>
    where TCommandRequest : ICommand
{
}