namespace AwsConfiguration;

public sealed class PollyPolicy : IPollyPolicy
{
    private readonly IComplementaryConfig _complementaryConfig;

    public PollyPolicy(IComplementaryConfig complementaryConfig)
    {
        _complementaryConfig = complementaryConfig;
    }

    public AsyncRetryPolicy RetryPolicyConnect()
    {
        return Policy.Handle<Exception>()
                     .WaitAndRetryAsync(
                        _complementaryConfig.Retry,
                        (int retryAttempt) => TimeSpan.FromSeconds(Math.Pow(2.0, retryAttempt)),
                        delegate(Exception ex, TimeSpan time)
                        {
                            //Todo Criar log? Serilog?
                            Console.WriteLine(ex);
                        }
                     );
    }

    public AsyncRetryPolicy RetryPolicyEvent(Guid eventId)
    {
        return Policy.Handle<Exception>()
                     .WaitAndRetryAsync(
                        _complementaryConfig.Retry,
                        (int retryAttempt) => TimeSpan.FromSeconds(Math.Pow(2.0, retryAttempt)),
                        delegate(Exception ex, TimeSpan time)
                        {
                            //Todo Criar log? Serilog?
                            Console.WriteLine(ex);
                        }
                     );
    }
}
