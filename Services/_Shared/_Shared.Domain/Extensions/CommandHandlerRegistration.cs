namespace _Shared.Domain.Extensions;

public static class HandlerRegistration
{
    public static IServiceCollection RegisterCommandHandler<TCommandHandler, TCommand, TCommandResult>(this IServiceCollection services)
        where TCommand : class, ICommand
        where TCommandHandler : class, ICommandHandler<TCommand, TCommandResult>
    {
        services.AddScoped<ICommandHandler<TCommand, TCommandResult>, TCommandHandler>();
        return services;
    }

    public static IServiceCollection RegisterQueryHandler<TQueryHandler, TQuery, TQueryResult>(this IServiceCollection services)
        where TQuery : class, IQuery
        where TQueryHandler : class, IQueryHandler<TQuery, TQueryResult>
    {
        services.AddScoped<IQueryHandler<TQuery, TQueryResult>, TQueryHandler>();
        return services;
    }
}
