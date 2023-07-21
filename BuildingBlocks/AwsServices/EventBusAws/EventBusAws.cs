namespace EventBusAws;

public abstract class EventBusAws : IEventBusAws
{
    private static string Environment => System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")!;
    protected IEventBusSubscriptionsManager SubsManager { get; private set; }
    private readonly IAmazonSimpleNotificationService _amazonSNS;
    private readonly IAmazonSQS _amazonSQS;
    private readonly IPollyPolicy _pollyPolicy;

    protected EventBusAws(
        IEventBusSubscriptionsManager subsManager,
        IPollyPolicy pollyPolicy,
        IAmazonSimpleNotificationService amazonSNS,
        IAmazonSQS amazonSQS)
    {
        SubsManager = subsManager;
        _pollyPolicy = pollyPolicy;
        _amazonSNS = amazonSNS;
        _amazonSQS = amazonSQS;
    }

    private string GetTopicNameAws<TIntegrationEvent>()
        where TIntegrationEvent : IntegrationEvent
    {
        return $"{Environment}{SubsManager.GetEventKey<TIntegrationEvent>()}";
    }

    private string GetContextName<TIntegrationEvent>()
        where TIntegrationEvent : IntegrationEvent
    {
        return typeof(TIntegrationEvent).FullName.Split(".").First();
    }

    private string GetQueueNameAws<TIntegrationEvent>()
        where TIntegrationEvent : IntegrationEvent
    {
        var contextName = GetContextName<TIntegrationEvent>();
        var integrationEventName = SubsManager.GetEventKey<TIntegrationEvent>();

        return $"{Environment}{contextName}{integrationEventName}";
    }

    public async Task PublishAsync(IntegrationEvent integrationEvent)
    {
        var messageAttributes = new Dictionary<string, SNSMessageAttributeValue>
            {
                {
                    nameof(integrationEvent.IntegrationTypeName),
                    new SNSMessageAttributeValue
                    {
                        StringValue = integrationEvent.IntegrationTypeName,
                        DataType = "String"
                    }
                }
            };

        var policy = _pollyPolicy.RetryPolicyEvent(integrationEvent.Id);

        await policy.ExecuteAsync(async () =>
        {
            var responseTopic = await _amazonSNS.FindTopicAsync(integrationEvent.IntegrationTypeName);

            await _amazonSNS.PublishAsync(new PublishRequest
            {
                TopicArn = responseTopic.TopicArn,
                Message = JsonIntegrationSerializer.Serialize(@integrationEvent),
                MessageAttributes = messageAttributes
            });
        });
    }

    public async Task SubscribeAsync<TIntegrationEvent, TIntegrationEventHandler>()
        where TIntegrationEvent : IntegrationEvent
        where TIntegrationEventHandler : IIntegrationEventHandler<TIntegrationEvent>
    {
        SubsManager.AddSubscription<TIntegrationEvent, TIntegrationEventHandler>();

        var policy = _pollyPolicy.RetryPolicyEvent(Guid.NewGuid());

        await policy.ExecuteAsync(async () =>
        {
            var responseTopic = await _amazonSNS.FindTopicAsync(GetTopicNameAws<TIntegrationEvent>());

            var responseQueue = await _amazonSQS.CreateQueueAsync(new CreateQueueRequest
            {
                QueueName = GetQueueNameAws<TIntegrationEvent>(),
            });

            await _amazonSNS.SubscribeAsync(new SubscribeRequest
            {
                TopicArn = responseTopic.TopicArn,
                Endpoint = responseQueue.QueueUrl,
                Protocol = "http"
            });
        });
    }

    public async Task UnsubscribeAsync<TIntegrationEvent, TIntegrationEventHandler>()
        where TIntegrationEvent : IntegrationEvent
        where TIntegrationEventHandler : IIntegrationEventHandler<TIntegrationEvent>
    {
        var responseTopic = await _amazonSNS.FindTopicAsync(GetTopicNameAws<TIntegrationEvent>());

        var subscriptionsTopic = await _amazonSNS.ListSubscriptionsByTopicAsync(responseTopic.TopicArn);

        if (subscriptionsTopic.HttpStatusCode == HttpStatusCode.OK)
        {
            foreach (var subscription in subscriptionsTopic.Subscriptions)
            {
                await _amazonSNS.UnsubscribeAsync(subscription.SubscriptionArn);
            }
        }

        SubsManager.RemoveSubscription<TIntegrationEvent, TIntegrationEventHandler>();
    }

    public async Task CreateTopicAsync<TIntegrationEvent>()
        where TIntegrationEvent : IntegrationEvent
    {
        var policy = _pollyPolicy.RetryPolicyEvent(Guid.NewGuid());

        await policy.ExecuteAsync(async () =>
        {
            await _amazonSNS.CreateTopicAsync(new CreateTopicRequest
            {
                Name = GetTopicNameAws<TIntegrationEvent>(),
            });
        });
    }

    public async Task DeleteTopicAsync<TIntegrationEvent>()
        where TIntegrationEvent : IntegrationEvent
    {
        var policy = _pollyPolicy.RetryPolicyEvent(Guid.NewGuid());

        await policy.ExecuteAsync(async () =>
        {
            var responseTopic = await _amazonSNS.FindTopicAsync(GetTopicNameAws<TIntegrationEvent>());

            await _amazonSNS.DeleteTopicAsync(responseTopic.TopicArn);
        });
    }
}
