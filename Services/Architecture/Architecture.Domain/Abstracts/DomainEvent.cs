﻿namespace Architecture.Domain.Abstracts;

public abstract record DomainEvent : INotification
{
    public Guid DomainEventId { get; private set; }

    protected DomainEvent()
    {
        DomainEventId = Guid.NewGuid();
    }
}