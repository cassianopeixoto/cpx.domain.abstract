using CPX.Domain.Abstract.Entities;
using CPX.Domain.Abstract.Identifiers;
using CPX.Domain.Abstract.Events;
using ReflectionMagic;

public abstract class AggregateRoot<TIdentity> : Entity where TIdentity : Identifier
{
    private readonly List<DomainEvent> uncommitedEvents = new List<DomainEvent>();

    protected AggregateRoot() { }

    protected AggregateRoot(Identifier aggregateId, DateTimeOffset createdAt) : base(aggregateId, createdAt)
    {
    }

    public int Version { get; protected set; } = 0;

    protected void Raise(DomainEvent @event)
    {
        if (uncommitedEvents.Any(o => o.Version.Equals(@event.Version)).Equals(false))
        {
            Version = @event.Version;
            uncommitedEvents.Add(@event);
            this.AsDynamic().Apply(@event);
        }
    }

    protected void Apply(DomainEvent @event)
    {
        Id = @event.Id;
        Version = @event.Version;
        CreatedAt = @event.CreatedAt;
        UpdatedAt = @event.CreatedAt;
    }

    public IReadOnlyCollection<DomainEvent> GetUncommitedEvents()
    {
        return uncommitedEvents.AsReadOnly();
    }

    public void Commit()
    {
        uncommitedEvents.Clear();
    }
}