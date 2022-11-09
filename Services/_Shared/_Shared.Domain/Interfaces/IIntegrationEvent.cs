namespace _Shared.Domain.Interfaces;

public interface IIntegrationEvent
{
    Guid Id { get; }
    DateTime CreatedAt { get; }
    string IntegrationTypeName { get; }
}
