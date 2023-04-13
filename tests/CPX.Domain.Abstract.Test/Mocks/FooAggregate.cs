using CPX.Domain.Abstract.Events;

namespace CPX.Domain.Abstract.Test.Mocks;

public class FooAggregate : AggregateRoot<FooId>, IApplyDomainEvent<FooDomainEvent>
{
    public FooAggregate() { }

    public FooAggregate(FooId fooId, DateTimeOffset createdAt) : base(fooId, createdAt)
    {
        Raise(new FooDomainEvent(fooId, Version + 1, createdAt));
    }

    public void Apply(FooDomainEvent @event)
    {
        base.Apply(@event);
    }
}