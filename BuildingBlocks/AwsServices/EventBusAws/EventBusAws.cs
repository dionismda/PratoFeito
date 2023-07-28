using EventBus.Extensions;
using EventBus.Interfaces;

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

    private string GetContextName<TIntegrationEvent, TIntegrationEventHandler>()
        where TIntegrationEvent : IntegrationEvent
        where TIntegrationEventHandler : IIntegrationEventHandler<TIntegrationEvent>
    {
        return typeof(TIntegrationEventHandler).FullName.Split(".").First();
    }

    private string GetQueueNameAws<TIntegrationEvent, TIntegrationEventHandler>()
        where TIntegrationEvent : IntegrationEvent
        where TIntegrationEventHandler : IIntegrationEventHandler<TIntegrationEvent>
    {
        var contextName = GetContextName<TIntegrationEvent, TIntegrationEventHandler>();
        var integrationEventName = SubsManager.GetEventKey<TIntegrationEvent>();

        return $"{Environment}{contextName}{integrationEventName}";
    }

    public async Task PublishAsync(IntegrationEvent integrationEvent)
    {
        using (new EventBusLog(nameof(EventBusAws), "PublishAsync").CreateLog())
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
                var responseTopic = await _amazonSNS.FindTopicAsync($"{Environment}{integrationEvent.IntegrationTypeName}");

                await _amazonSNS.PublishAsync(new PublishRequest
                {
                    TopicArn = responseTopic.TopicArn,
                    Message = JsonIntegrationSerializer.Serialize(@integrationEvent),
                    MessageAttributes = messageAttributes
                });
            });
        }
    }

    public async Task SubscribeAsync<TIntegrationEvent, TIntegrationEventHandler>()
        where TIntegrationEvent : IntegrationEvent
        where TIntegrationEventHandler : IIntegrationEventHandler<TIntegrationEvent>
    {
        using (new EventBusLog(nameof(EventBusAws), "SubscribeAsync").CreateLog())
        {
            SubsManager.AddSubscription<TIntegrationEvent, TIntegrationEventHandler>();

            var policy = _pollyPolicy.RetryPolicyEvent(Guid.NewGuid());

            await policy.ExecuteAsync(async () =>
            {
                var responseTopic = await _amazonSNS.FindTopicAsync(GetTopicNameAws<TIntegrationEvent>());

                var responseQueue = await _amazonSQS.CreateQueueAsync(new CreateQueueRequest
                {
                    QueueName = GetQueueNameAws<TIntegrationEvent, TIntegrationEventHandler>(),
                });

                await _amazonSNS.SubscribeAsync(new SubscribeRequest
                {
                    TopicArn = responseTopic.TopicArn,
                    Endpoint = responseQueue.QueueUrl,
                    Protocol = "http"
                });
            });
        }
    }

    public async Task UnsubscribeAsync<TIntegrationEvent, TIntegrationEventHandler>()
        where TIntegrationEvent : IntegrationEvent
        where TIntegrationEventHandler : IIntegrationEventHandler<TIntegrationEvent>
    {
        using (new EventBusLog(nameof(EventBusAws), "SubscribeAsync").CreateLog())
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
    }

    public async Task CreateTopicAsync<TIntegrationEvent>()
        where TIntegrationEvent : IntegrationEvent
    {
        using (new EventBusLog(nameof(EventBusAws), "SubscribeAsync").CreateLog())
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
    }

    public async Task DeleteTopicAsync<TIntegrationEvent>()
        where TIntegrationEvent : IntegrationEvent
    {
        using (new EventBusLog(nameof(EventBusAws), "SubscribeAsync").CreateLog())
        {
            var policy = _pollyPolicy.RetryPolicyEvent(Guid.NewGuid());

            await policy.ExecuteAsync(async () =>
            {
                var responseTopic = await _amazonSNS.FindTopicAsync(GetTopicNameAws<TIntegrationEvent>());

                await _amazonSNS.DeleteTopicAsync(responseTopic.TopicArn);
            });
        }
    }
}
