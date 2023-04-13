using CPX.Domain.Abstract.Entities;
using CPX.Domain.Abstract.Identifiers;

namespace CPX.Domain.Abstract.Test.Entities;

public class EntityTest
{
    [Fact]
    public void Should_be_able_to_create()
    {
        // Arrange
        var id = Guid.NewGuid();
        var mockIdentifier = new Mock<Identifier>(id);
        var identifier = mockIdentifier.Object;
        var createdAt = DateTimeOffset.Now;
        // Act
        var entityMock = new Mock<Entity>(identifier, createdAt);
        var entity = entityMock.Object;
        // Assert
        Assert.Equal(identifier, entity.Id);
        Assert.Equal(createdAt, entity.CreatedAt);
    }
}