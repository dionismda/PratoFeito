namespace AwsConfiguration.Interfaces;

public interface IPollyPolicy
{
    AsyncRetryPolicy RetryPolicyEvent(Guid eventId);

    AsyncRetryPolicy RetryPolicyConnect();
}
