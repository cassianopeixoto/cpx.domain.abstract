using CPX.Domain.Abstract.Aggregates;
using CPX.Domain.Abstract.Identifiers;
using CPX.Domain.Abstract.Test.Mocks;

namespace CPX.Domain.Abstract.Test.Aggregates;

public class EventSourceAggregateTest
{
    [Fact]
    public void Should_be_able_to_create()
    {
        // Arrange
        var aggregateId = Identifier.New();
        var createdAt = DateTimeOffset.Now;
        var createdBy = Identifier.New();
        // Act
        var mockAggregateRoot = new Mock<EventSourceAggregate>(aggregateId, createdAt, createdBy);
        var aggregate = mockAggregateRoot.Object;
        // Assert
        Assert.Equal(aggregateId, aggregate.Id);
        Assert.Equal(createdAt, aggregate.CreatedAt);
        Assert.Equal(createdAt, aggregate.UpdatedAt);
        Assert.Equal(createdBy.Value, aggregate.UpdatedBy);
    }

    [Fact]
    public void Should_be_able_to_raise_event()
    {
        // Arrange
        var id = Guid.NewGuid();
        var fooId = new FooId(id);
        var createdAt = DateTimeOffset.Now;
        var createdBy = Identifier.New();
        var foo = "foo";
        var version = 1;
        // Act
        var fooAggregate = new FooAggregate(fooId, createdAt, createdBy, foo);
        // Assert
        Assert.Equal(fooId, fooAggregate.Id);
        Assert.Equal(createdAt, fooAggregate.CreatedAt);
        Assert.Equal(createdAt, fooAggregate.UpdatedAt);
        Assert.Equal(createdBy.Value, fooAggregate.UpdatedBy);
        Assert.Equal(version, fooAggregate.Version);
        Assert.Equal(fooAggregate.Version, fooAggregate.UncommittedEvents.Count);

        var @event = fooAggregate.UncommittedEvents.Single() as FooDomainEvent;

        Assert.NotNull(@event);

        if (@event is not null)
        {
            Assert.Equal(id.ToString(), @event.AggregateId);
            Assert.Equal(createdAt, @event.CreatedAt);
            Assert.Equal(createdBy.Value, @event.CreatedBy);
            Assert.Equal(foo, @event.Foo);

            fooAggregate.Commit();

            Assert.Empty(fooAggregate.UncommittedEvents);
        }
    }
}