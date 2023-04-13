namespace CPX.Domain.Abstract.Events;

using CPX.Events.Abstract;

public abstract class DomainEvent : Event
{
    protected DomainEvent(Guid aggregateId, int version, DateTimeOffset createdAt) : base(createdAt)
    {
        AggregateId = aggregateId.ToString();
        Version = version;
    }

    public string AggregateId { get; }
    public int Version { get; }
}