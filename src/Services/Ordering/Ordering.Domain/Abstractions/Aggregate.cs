
namespace Ordering.Domain.Abstractions;
public abstract class Aggregate<TId> : Entity<TId>, IAggregate<TId>
{
    public IReadOnlyList<IDomainEvent> DomainEvents => throw new NotImplementedException();

    public IDomainEvent[] ClearDdomainEvents()
    {
        throw new NotImplementedException();
    }
}

