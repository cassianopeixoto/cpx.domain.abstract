namespace CPX.Domain.Abstract.Events;

using CPX.Events.Abstract;

public abstract class DomainEvent(Guid aggregateId, DateTimeOffset createdAt, Guid createdBy) : Event(createdAt)
{
    public string AggregateId { get; init; } = aggregateId.ToString();
    public Guid CreatedBy { get; init; } = createdBy;
}