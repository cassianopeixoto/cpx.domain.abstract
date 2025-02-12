using CPX.Domain.Abstract.Aggregates;
using CPX.Domain.Abstract.Events;
using CPX.Domain.Abstract.Identifiers;

namespace CPX.Domain.Abstract.Test.Mocks;

public sealed class FooAggregate : EventSourceAggregate, IApplyDomainEvent<FooDomainEvent>
{
    public string Foo { get; private set; } = string.Empty;

    public FooAggregate(Identifier aggregateId, DateTimeOffset createdAt, Guid createdBy, string foo) : base(aggregateId, createdAt, createdBy)
    {
        Raise(new FooDomainEvent(aggregateId, createdAt, createdBy, foo));
    }

    public void Apply(FooDomainEvent @event)
    {
        Foo = @event.Foo;
    }
}