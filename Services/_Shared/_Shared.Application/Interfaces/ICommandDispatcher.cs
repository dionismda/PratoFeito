namespace _Shared.Application.Interfaces;

public interface ICommandDispatcher
{
    Task<TResultCommand> Handle<TCommand, TResultCommand>(TCommand command, CancellationToken cancellationToken)
        where TCommand : class, ICommand;
}
