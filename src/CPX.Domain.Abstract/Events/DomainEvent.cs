namespace CPX.Domain.Abstract.Events;

using CPX.Events.Abstract;

public abstract class DomainEvent : Event
{
    protected DomainEvent(Guid aggregateId, int version, DateTimeOffset createdAt, Guid createdBy) : base(createdAt)
    {
        AggregateId = aggregateId.ToString();
        Version = version;
        CreatedBy = createdBy;
    }

    public string AggregateId { get; }
    public int Version { get; }
    public Guid CreatedBy { get; }
}