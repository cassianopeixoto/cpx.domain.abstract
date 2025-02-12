using CPX.Domain.Abstract.Entities;
using CPX.Domain.Abstract.Identifiers;

namespace CPX.Domain.Abstract.Test.Entities;

public class EntityTest
{
    [Fact]
    public void Should_be_able_to_create()
    {
        // Arrange
        var id = Identifier.New();
        var createdAt = DateTimeOffset.Now;
        var updatedBy = Guid.NewGuid();
        var updatedAt = DateTimeOffset.Now;
        // Act
        var entityMock = new Mock<Entity>(id, createdAt, updatedBy, updatedAt);
        var entity = entityMock.Object;
        // Assert
        Assert.Equal(id, entity.Id);
        Assert.Equal(createdAt, entity.CreatedAt);
        Assert.Equal(updatedBy, entity.UpdatedBy);
        Assert.Equal(updatedAt, entity.UpdatedAt);
    }
}