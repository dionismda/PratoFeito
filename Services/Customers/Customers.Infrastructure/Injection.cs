using _Architecture.Infrastructure.MassTransit;
using Amazon.SimpleNotificationService;
using Amazon.SQS;
using Customers.Infrastructure.Masstransit;
using Customers.Infrastructure.Masstransit.Consumers;
using MassTransit;
using System.Reflection;

namespace Customers.Infrastructure;

public static class Injection
{
    public static IServiceCollection InjectionCustomersInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CustomersContext>();

        services.AddDapperNpgSqlConnection();

        services.ConfigureMassTransit(x =>
        {
            x.AddConsumer<OrderProcessInitializationEventConsumer>();
            x.AddRequestClient<OrderProcessInitializationEventConsumer>();

            x.AddConsumer<OrderProcessInitializationFaultEventConsumer>();
            x.AddRequestClient<OrderProcessInitializationFaultEventConsumer>();

            x.AddConsumer<CheckProductStockEventConsumer>();
            x.AddRequestClient<CheckProductStockEventConsumer>();

            x.AddConsumer<CheckProductStockFaultEventConsumer>();
            x.AddRequestClient<CheckProductStockFaultEventConsumer>();

            x.AddConsumer<TakePaymentEventConsumer>();
            x.AddRequestClient<TakePaymentEventConsumer>();

            x.AddConsumer<TakePaymentFaultEventConsumer>();
            x.AddRequestClient<TakePaymentFaultEventConsumer>();

            x.AddConsumer<CreateOrderEventConsumer>();
            x.AddRequestClient<CreateOrderEventConsumer>();

            x.AddConsumer<CreateOrderFaultEventConsumer>();
            x.AddRequestClient<CreateOrderFaultEventConsumer>();

            x.AddConsumer<OrderProcessFailedEventConsumer>();
            x.AddRequestClient<OrderProcessFailedEventConsumer>();

            x.AddSagaStateMachine<OrderStateMachine, OrderState, OrderStateDefinition>()
                .EntityFrameworkRepository(r =>
                {
                    r.ExistingDbContext<CustomersContext>();
                    r.UsePostgres();
                });
        });

        services
            .InjectionCustomers()
            .InjectionCustomerOrders();

        return services;
    }

    private static IServiceCollection InjectionCustomers(this IServiceCollection services)
    {
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<ICustomerQueries, CustomerQueries>();

        return services;
    }

    private static IServiceCollection InjectionCustomerOrders(this IServiceCollection services)
    {
        services.AddScoped<ICustomerOrderRepository, CustomerOrderRepository>();

        return services;
    }
}
