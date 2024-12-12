namespace Ordering.Domain.Abstractions;
public abstract class Aggregate<TId> : Entity<TId>, IAggregate<TId>
{
    private readonly List<IDomainEvent> _doaminEvents = new();
    public IReadOnlyList<IDomainEvent> DomainEvents => _doaminEvents.AsReadOnly();

    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        _doaminEvents.Add(domainEvent);
    }

    public IDomainEvent[] ClearDdomainEvents()
    {
        IDomainEvent[] dequeuedEvents = _doaminEvents.ToArray();

        _doaminEvents.Clear();
        
        return dequeuedEvents;
    }
}

