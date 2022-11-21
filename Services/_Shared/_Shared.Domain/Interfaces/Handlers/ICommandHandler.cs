namespace _Shared.Domain.Interfaces.Handlers;

public interface ICommandHandler<in TCommand> : IHandler
    where TCommand : class, ICommand
{
    Task Handle(TCommand command, CancellationToken cancellation);
}

public interface ICommandHandler<in TCommand, TResponse> : IHandler
    where TCommand : class, ICommand
{
    Task<TResponse> Handle(TCommand command, CancellationToken cancellation);
}
