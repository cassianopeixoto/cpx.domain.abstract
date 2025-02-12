using CPX.Domain.Abstract.Events;

namespace CPX.Domain.Abstract.Test.Mocks;

public class FooDomainEvent(Guid aggregateId, DateTimeOffset createdAt, Guid createdBy, string foo) : DomainEvent(aggregateId, createdAt, createdBy)
{
    public string Foo { get; init; } = foo;
}