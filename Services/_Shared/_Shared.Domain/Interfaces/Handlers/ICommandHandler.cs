namespace _Shared.Domain.Interfaces.Handlers;

public interface ICommandHandler<in TCommand, TCommandResult> : IHandler
    where TCommand : class, ICommand
{
    Task<TCommandResult> Handle(TCommand command, CancellationToken cancellation);
}
