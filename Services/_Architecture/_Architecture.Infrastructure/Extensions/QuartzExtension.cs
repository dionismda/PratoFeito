namespace _Architecture.Infrastructure.Extensions;

public static class QuartzExtension
{
    public static IServiceCollection AddQuartzJobInSeconds<TIntegrationEventLogBackgroundService>(this IServiceCollection services, int seconds)
        where TIntegrationEventLogBackgroundService : IntegrationEventLogBackgroundService
    {
        services
            .AddQuartz(quartz =>
            {
                var jobKey = new JobKey(typeof(TIntegrationEventLogBackgroundService).Name);

                quartz.AddJob<TIntegrationEventLogBackgroundService>(job => job.WithIdentity(jobKey));

                quartz.AddTrigger(trigger =>
                        {
                            trigger
                                .ForJob(jobKey)
                                .WithIdentity(typeof(TIntegrationEventLogBackgroundService).Name + "-trigger")
                                .WithSimpleSchedule(schedule =>
                                {
                                    schedule.WithIntervalInSeconds(seconds)
                                            .RepeatForever();
                                });
                        })
                       .UseMicrosoftDependencyInjectionJobFactory();
            });

        return services;
    }
}
