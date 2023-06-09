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
        var version = 1;
        var createdAt = DateTimeOffset.Now;
        var createdBy = Guid.NewGuid();
        // Act
        var domainEvent = new FooDomainEvent(aggregateId, version, createdAt, createdBy);
        // Assert
        Assert.IsAssignableFrom<DomainEvent>(domainEvent);
        Assert.Equal(id, domainEvent.AggregateId);
        Assert.Equal(version, domainEvent.Version);
        Assert.Equal(createdAt, domainEvent.CreatedAt);
        Assert.Equal(createdBy, domainEvent.CreatedBy);
    }

    [Fact]
    public void Should_be_able_to_serialized_domain_event()
    {
        // Arrange
        var aggregateId = Guid.Parse("65aee9c3-4d97-499a-943f-e8be93c31fd3");
        var version = 1;
        var createdAt = new DateTimeOffset(new DateTime(2013, 4, 13));
        var createdBy = Guid.Parse("65aee9c3-4d97-499a-943f-e8be93c31fd2");
        // Act
        var @event = new FooDomainEvent(aggregateId, version, createdAt, createdBy);
        var serialized = JsonEventConvert.Serialize(@event);
        // Assert
        Assert.Equal("{\"aggregateId\":\"65aee9c3-4d97-499a-943f-e8be93c31fd3\",\"version\":1,\"createdBy\":\"65aee9c3-4d97-499a-943f-e8be93c31fd2\",\"createdAt\":\"2013-04-13T00:00:00+01:00\"}", serialized);
    }

    [Fact]
    public void Should_be_able_to_deserialize_domain_event()
    {
        // Arrange
        var aggregateId = Guid.Parse("65aee9c3-4d97-499a-943f-e8be93c31fd3");
        var version = 1;
        var createdAt = new DateTimeOffset(new DateTime(2013, 4, 13));
        var createdBy = Guid.Parse("65aee9c3-4d97-499a-943f-e8be93c31fd2");
        // Act
        var @event = new FooDomainEvent(aggregateId, version, createdAt, createdBy);
        var serialized = JsonEventConvert.Serialize(@event);
        var deserializedEvent = JsonEventConvert.Deserialize<FooDomainEvent>(serialized);
        // Assert
        Assert.NotNull(deserializedEvent);
        if (deserializedEvent != null)
        {
            Assert.Equal(aggregateId.ToString(), deserializedEvent.AggregateId);
            Assert.Equal(version, deserializedEvent.Version);
            Assert.Equal(createdAt, deserializedEvent.CreatedAt);
            Assert.Equal(createdBy, deserializedEvent.CreatedBy);
        }
    }
}