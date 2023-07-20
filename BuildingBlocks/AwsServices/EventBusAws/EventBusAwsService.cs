namespace EventBusAws;

public sealed class EventBusAwsService : IEventBus, IDisposable
{
    private readonly IEventBusSubscriptionsManager _subsManager;
    private readonly IAmazonSimpleNotificationService _amazonSNS;
    private readonly IAmazonSQS _amazonSQS;
    private readonly IPollyPolicy _pollyPolicy;

    public EventBusAwsService(
        IEventBusSubscriptionsManager subsManager,
        IPollyPolicy pollyPolicy,
        IAmazonSimpleNotificationService amazonSNS,
        IAmazonSQS amazonSQS)
    {
        _subsManager = subsManager;
        _pollyPolicy = pollyPolicy;
        _amazonSNS = amazonSNS;
        _amazonSQS = amazonSQS;
    }

    private async Task<string> CreateTopic(string integrationEventName)
    {
        var response = await _amazonSNS.CreateTopicAsync(new CreateTopicRequest
        {
            Name = integrationEventName,
        });

        return response.TopicArn;
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
            var topicArn = await CreateTopic(integrationEvent.IntegrationTypeName);

            await _amazonSNS.PublishAsync(new PublishRequest
            {
                TopicArn = topicArn,
                Message = JsonIntegrationSerializer.Serialize(@integrationEvent),
                MessageAttributes = messageAttributes
            });
        });
    }

    public async Task SubscribeAsync<TIntegrationEvent, TIntegrationEventHandler>()
        where TIntegrationEvent : IntegrationEvent
        where TIntegrationEventHandler : IIntegrationEventHandler<TIntegrationEvent>
    {
        var policy = _pollyPolicy.RetryPolicyEvent(Guid.NewGuid());

        await policy.ExecuteAsync(async () =>
        {
            var responseQueue = await _amazonSQS.CreateQueueAsync(new CreateQueueRequest
            {
                QueueName = typeof(TIntegrationEvent).FullName,
            });

            var topicArn = await CreateTopic(typeof(TIntegrationEvent).Name);

            await _amazonSNS.SubscribeAsync(new SubscribeRequest
            {
                TopicArn = topicArn,
                Endpoint = responseQueue.QueueUrl,
                Protocol = "https"
            });

        });

        _subsManager.AddSubscription<TIntegrationEvent, TIntegrationEventHandler>();
    }

    public Task UnsubscribeAsync<TIntegrationEvent, TIntegrationEventHandler>()
        where TIntegrationEvent : IntegrationEvent
        where TIntegrationEventHandler : IIntegrationEventHandler<TIntegrationEvent>
    {
        //_subsManager.RemoveSubscription<TIntegrationEvent, TIntegrationEventHandler>();
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        _subsManager.Clear();
    }
}
