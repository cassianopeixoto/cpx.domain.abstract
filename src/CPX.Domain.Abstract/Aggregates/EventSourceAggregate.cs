using CPX.Domain.Abstract.Entities;
using CPX.Domain.Abstract.Events;
using CPX.Domain.Abstract.Identifiers;

namespace CPX.Domain.Abstract.Aggregates;

public abstract class EventSourceAggregate(Identifier aggregateId, DateTimeOffset createdAt, Identifier createdBy) : Entity(aggregateId, createdAt, createdBy, createdAt)
{
    private readonly IList<DomainEvent> _uncommittedEvents = [];

    public int Version { get; private set; } = 0;

    public IReadOnlyCollection<DomainEvent> UncommittedEvents => _uncommittedEvents.AsReadOnly();

    public void LoadFromHistory(IReadOnlyCollection<DomainEvent> history)
    {
        foreach (DomainEvent @event in history)
        {
            Apply(@event);
        }
    }

    public void Commit() => _uncommittedEvents.Clear();

    protected void Raise(DomainEvent @event)
    {
        _uncommittedEvents.Add(@event);
        Apply(@event);
    }

    private void Apply(DomainEvent @event)
    {
        var interfaceType = typeof(IApplyDomainEvent<>).MakeGenericType(@event.GetType());

        if (interfaceType.IsInstanceOfType(this))
        {
            var method = interfaceType.GetMethod("Apply");
            method?.Invoke(this, new object[] { @event });

            UpdatedAt = @event.CreatedAt;
            UpdatedBy = @event.CreatedBy;
            Version++;
        }
    }
}
