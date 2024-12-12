namespace Ordering.Domain.Abstractions;

public interface IDomainEvent : INotification
{
    Guid EventId => Guid.NewGuid();

    public DateTime OccuredIn => DateTime.Now;

    public string EventType => GetType().AssemblyQualifiedName;
}

