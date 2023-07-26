using MassTransit;

namespace Customers.Infrastructure.Masstransit.Consumers;

public abstract class ConsumerBase<T> : IConsumer<T>
    where T : class
{
    public async Task Consume(ConsumeContext<T> context)
    {
        try
        {
            await ConsumeInternal(context);
        }
        catch (Exception)
        {
            await context.Publish<Fault<T>>(context);

            // global exception handling
            throw;
        }
    }

    protected abstract Task ConsumeInternal(ConsumeContext<T> context);
}
