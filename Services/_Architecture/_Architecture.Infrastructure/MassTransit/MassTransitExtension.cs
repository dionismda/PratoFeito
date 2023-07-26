using _Architecture.Infrastructure.Abstractions;
using Amazon.SimpleNotificationService;
using Amazon.SQS;
using MassTransit;
using System.Reflection;

namespace _Architecture.Infrastructure.MassTransit;

public static class MassTransitExtension
{
    public static IServiceCollection ConfigureMassTransit(this IServiceCollection services, Action<IBusRegistrationConfigurator>? configure = null)
    {
        services.AddMassTransit(busConfigurator =>
        {
            busConfigurator.UsingAmazonSqs((context, config) =>
            {
                var teste = "amazonsqs://localstack:4566";

                var uri = new Uri(teste);

                config.Host(uri, h =>
                {
                    h.AccessKey("teste");
                    h.SecretKey("teste123");
                    h.Config(new AmazonSimpleNotificationServiceConfig { ServiceURL = "http://localstack:4566" });
                    h.Config(new AmazonSQSConfig { ServiceURL = "http://localstack:4566" });
                });

                var formatter = new CustomFormatter(new DefaultEndpointNameFormatter(true));
                config.MessageTopology.SetEntityNameFormatter(formatter);
                config.ConfigureEndpoints(context, formatter);
            });

            configure.Invoke(busConfigurator);
        });

        return services;
    }

}
