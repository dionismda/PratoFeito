namespace _Architecture.Infrastructure.Extensions;

public static class EventBusAwsExtension
{
    public static void AddEventBusAwsService(this IServiceCollection services, IConfiguration configuration)
    {
        var awsCredentials = configuration.GetSection("Amazon:Credentials").Get<AwsCredentials>();
        var credentials = new BasicAWSCredentials(awsCredentials.AccessKey, awsCredentials.SecretKey);

        services.AddSingleton<IComplementaryConfig, ComplementaryAwsConfig>();
        services.AddSingleton<IPollyPolicy, PollyPolicy>(sp =>
        {
            var complementaryConfig = sp.GetRequiredService<IComplementaryConfig>();
            return new PollyPolicy(complementaryConfig);
        });

        services.AddSingleton<IAmazonSimpleNotificationService, AmazonSimpleNotificationServiceClient>(sp =>
        {
            var snsConfiguration = new AmazonSimpleNotificationServiceConfig
            {
                RegionEndpoint = RegionEndpoint.GetBySystemName(awsCredentials.Region)
            };

            //Validação necessaria para trabalhar com o LOCALSTACK
            if (awsCredentials.ServiceUrl != null)
            {
                snsConfiguration.ServiceURL = awsCredentials.ServiceUrl;
            }

            return new AmazonSimpleNotificationServiceClient(credentials, snsConfiguration);
        });

        services.AddSingleton<IAmazonSQS, AmazonSQSClient>(sp =>
        {
            var sqsConfiguration = new AmazonSQSConfig
            {
                RegionEndpoint = RegionEndpoint.GetBySystemName(awsCredentials.Region)
            };

            //Validação necessaria para trabalhar com o LOCALSTACK
            if (awsCredentials.ServiceUrl != null)
            {
                sqsConfiguration.ServiceURL = awsCredentials.ServiceUrl;
            }

            return new AmazonSQSClient(credentials, sqsConfiguration);
        });
    }
}