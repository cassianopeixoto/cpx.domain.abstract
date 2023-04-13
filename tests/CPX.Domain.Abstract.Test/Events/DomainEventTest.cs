using CPX.Domain.Abstract.Events;

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
        // Act
        var mockDomainEvent = new Mock<DomainEvent>(aggregateId, version, createdAt);
        var domainEvent = mockDomainEvent.Object;
        // Assert
        Assert.Equal(id, domainEvent.AggregateId);
        Assert.Equal(version, domainEvent.Version);
        Assert.Equal(createdAt, domainEvent.CreatedAt);
    }
}