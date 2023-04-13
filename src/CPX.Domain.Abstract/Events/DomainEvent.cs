namespace CPX.Domain.Abstract.Events;

using CPX.Events.Abstract;

public abstract class DomainEvent : Event
{
    protected DomainEvent(Guid aggregateId, int version, DateTimeOffset createdAt) : base(aggregateId.ToString(), version, createdAt)
    {
    }
}