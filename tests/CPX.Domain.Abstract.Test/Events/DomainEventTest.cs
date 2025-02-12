using CPX.Domain.Abstract.Events;
using CPX.Domain.Abstract.Test.Mocks;
using CPX.Events.Abstract;

namespace CPX.Domain.Abstract.Test.Events;

public class DomainEventTest
{
    [Fact]
    public void Should_be_able_to_create()
    {
        // Arrange
        var aggregateId = Guid.NewGuid();
        var id = aggregateId.ToString();
        var createdAt = DateTimeOffset.Now;
        var createdBy = Guid.NewGuid();
        var foo = "foo";
        // Act
        var @event = new FooDomainEvent(aggregateId, createdAt, createdBy, foo);
        // Assert
        Assert.IsAssignableFrom<DomainEvent>(@event);
        Assert.Equal(id, @event.AggregateId);
        Assert.Equal(createdAt, @event.CreatedAt);
        Assert.Equal(createdBy, @event.CreatedBy);
        Assert.Equal(foo, @event.Foo);
    }

    [Fact]
    public void Should_be_able_to_serialized_domain_event()
    {
        // Arrange
        var aggregateId = Guid.Parse("65aee9c3-4d97-499a-943f-e8be93c31fd3");
        var createdAt = new DateTimeOffset(new DateTime(2013, 4, 13));
        var createdBy = Guid.Parse("65aee9c3-4d97-499a-943f-e8be93c31fd2");
        var foo = "foo";
        // Act
        var @event = new FooDomainEvent(aggregateId, createdAt, createdBy, foo);
        var serialized = JsonEventConvert.Serialize(@event);
        // Assert
        Assert.Equal("{\"foo\":\"foo\",\"aggregateId\":\"65aee9c3-4d97-499a-943f-e8be93c31fd3\",\"createdBy\":\"65aee9c3-4d97-499a-943f-e8be93c31fd2\",\"createdAt\":\"2013-04-13T00:00:00+01:00\"}", serialized);
    }

    [Fact]
    public void Should_be_able_to_deserialize_domain_event()
    {
        // Arrange
        var aggregateId = Guid.Parse("65aee9c3-4d97-499a-943f-e8be93c31fd3");
        var createdAt = new DateTimeOffset(new DateTime(2013, 4, 13));
        var createdBy = Guid.Parse("65aee9c3-4d97-499a-943f-e8be93c31fd2");
        var foo = "foo";
        // Act
        var @event = new FooDomainEvent(aggregateId, createdAt, createdBy, foo);
        var serialized = JsonEventConvert.Serialize(@event);
        var deserializedEvent = JsonEventConvert.Deserialize<FooDomainEvent>(serialized);
        // Assert
        Assert.NotNull(deserializedEvent);
        if (deserializedEvent != null)
        {
            Assert.Equal(aggregateId.ToString(), deserializedEvent.AggregateId);
            Assert.Equal(createdAt, deserializedEvent.CreatedAt);
            Assert.Equal(createdBy, deserializedEvent.CreatedBy);
            Assert.Equal(foo, deserializedEvent.Foo);
        }
    }
}