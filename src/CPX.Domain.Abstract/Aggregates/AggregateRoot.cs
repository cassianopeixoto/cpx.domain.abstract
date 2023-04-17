using CPX.Domain.Abstract.Entities;
using CPX.Domain.Abstract.Identifiers;
using CPX.Domain.Abstract.Events;
using ReflectionMagic;

namespace CPX.Domain.Abstract.Aggregates;

public abstract class AggregateRoot<TIdentity> : Entity where TIdentity : Identifier
{
    private readonly List<DomainEvent> uncommitedEvents = new List<DomainEvent>();

    public int Version { get; protected set; } = 0;

    public IReadOnlyCollection<DomainEvent> GetUncommitedEvents()
    {
        return uncommitedEvents.AsReadOnly();
    }

    public void Commit()
    {
        uncommitedEvents.Clear();
    }

    protected void Raise(DomainEvent @event)
    {
        if (TheVersionDoesNotExist(@event.Version))
        {
            uncommitedEvents.Add(@event);
            this.AsDynamic().Apply(@event);
        }
    }

    protected void Apply(DomainEvent @event)
    {
        UpdatedAt = @event.CreatedAt;
        UpdatedBy = @event.CreatedBy;
        Version = @event.Version;
    }

    private bool TheVersionDoesNotExist(int version)
    {
        return uncommitedEvents.Any(o => o.Version.Equals(version)).Equals(false);
    }
}