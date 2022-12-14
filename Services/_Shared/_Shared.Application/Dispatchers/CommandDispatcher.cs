namespace _Shared.Application.Dispatchers;

public class CommandDispatcher : ICommandDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public CommandDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task<TResultCommand> Handle<TCommand, TResultCommand>(TCommand command, CancellationToken cancellationToken)
        where TCommand : class, ICommand
    {
        if (_serviceProvider.GetService(typeof(ICommandHandler<TCommand, TResultCommand>)) is not ICommandHandler<TCommand, TResultCommand> service)
            throw new InvalidCastException("Could not find CommandHandler injection");

        return await service.Handle((dynamic)command, cancellationToken);
    }
}