using CPX.Domain.Abstract.Aggregates;
using CPX.Domain.Abstract.Identifiers;
using CPX.Domain.Abstract.Test.Mocks;

public class AggregateRootTest
{
    [Fact]
    public void Should_be_able_to_create()
    {
        // Arrange
        var aggregateId = Guid.NewGuid();
        var mockIdentifier = new Mock<Identifier>(aggregateId);
        var identifier = mockIdentifier.Object;
        var createdAt = DateTimeOffset.Now;
        // Act
        var mockAggregateRoot = new Mock<AggregateRoot<Identifier>>(identifier, createdAt);
        var aggregate = mockAggregateRoot.Object;
        // Assert
        Assert.Equal(identifier, aggregate.Id);
        Assert.Equal(createdAt, aggregate.CreatedAt);
    }

    [Fact]
    public void Should_be_able_to_raise_event()
    {
        // Arrange
        var id = Guid.NewGuid();
        var fooId = new FooId(id);
        var createdAt = DateTimeOffset.Now;
        var version = 1;
        // Act
        var fooAggregate = new FooAggregate(fooId, createdAt);
        // Assert
        Assert.Equal(fooId, fooAggregate.Id);
        Assert.Equal(createdAt, fooAggregate.CreatedAt);
        Assert.Equal(createdAt, fooAggregate.UpdatedAt);
        Assert.Equal(version, fooAggregate.Version);
        Assert.Equal(fooAggregate.Version, fooAggregate.GetUncommitedEvents().Count);

        var @event = fooAggregate.GetUncommitedEvents().Single();
        Assert.IsType<FooDomainEvent>(@event);
        Assert.Equal(id.ToString(), @event.AggregateId);
        Assert.Equal(createdAt, @event.CreatedAt);

        fooAggregate.Commit();

        Assert.Empty(fooAggregate.GetUncommitedEvents());
    }

    [Fact]
    public void Should_be_able_to_apply_event()
    {
        // Arrange
        var id = new FooId(Guid.NewGuid());
        var version = 1;
        var createdAt = DateTimeOffset.Now;
        var @event = new FooDomainEvent(id, version, createdAt);
        // Act
        var aggregate = new FooAggregate();
        aggregate.Apply(@event);
        // Assert
        Assert.Equal(id, aggregate.Id);
        Assert.Equal(version, aggregate.Version);
        Assert.Equal(createdAt, aggregate.CreatedAt);
        Assert.Equal(createdAt, aggregate.UpdatedAt);
    }
}