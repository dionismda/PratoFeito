namespace Architecture.Application.Abstracts;

public abstract class CommandHandler<TAggregateRoot, TCommandRequest, TResponse> : ICommandHandler<TCommandRequest, TResponse>
    where TCommandRequest : ICommand<TResponse>
    where TAggregateRoot : AggregateRoot
{
    protected IDomainService<TAggregateRoot> DomainService { get; private set; }

    protected CommandHandler(IDomainService<TAggregateRoot> domainService)
    {
        DomainService = domainService;
    }

    public abstract Task<TResponse> Handle(TCommandRequest request, CancellationToken cancellationToken);
}

public abstract class CommandHandler<TAggregateRoot, TCommandRequest> : ICommandHandler<TCommandRequest>
    where TCommandRequest : ICommand
    where TAggregateRoot : AggregateRoot
{
    protected IDomainService<TAggregateRoot> DomainService { get; private set; }

    protected CommandHandler(IDomainService<TAggregateRoot> domainService)
    {
        DomainService = domainService;
    }

    public abstract Task Handle(TCommandRequest request, CancellationToken cancellationToken);
}