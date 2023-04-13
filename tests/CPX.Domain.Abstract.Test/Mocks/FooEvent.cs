using CPX.Domain.Abstract.Events;

namespace CPX.Domain.Abstract.Test.Mocks;

public class FooDomainEvent : DomainEvent
{
    public FooDomainEvent(Guid aggregateId, int version, DateTimeOffset createdAt) : base(aggregateId, version, createdAt)
    {
    }
}