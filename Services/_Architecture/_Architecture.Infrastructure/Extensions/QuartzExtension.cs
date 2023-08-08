﻿using Quartz;

namespace _Architecture.Infrastructure.Extensions;

public static class QuartzExtension
{
    public static IServiceCollection AddQuartzJobInSeconds<TIntegrationEventLogBackgroundService>(this IServiceCollection services, int seconds)
        where TIntegrationEventLogBackgroundService : IntegrationEventLogBackgroundService
    {
        services.AddQuartz(conf =>
        {
            var jobKey = new JobKey(nameof(TIntegrationEventLogBackgroundService));

            conf.AddJob<TIntegrationEventLogBackgroundService>(opts => opts.WithIdentity(jobKey))
                .AddTrigger(trigger =>
                {
                    trigger.ForJob(jobKey)
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
