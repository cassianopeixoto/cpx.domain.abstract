using CPX.Domain.Abstract.Identifiers;

namespace CPX.Domain.Abstract.Test.Identifiers;

public class IdentifierTest
{
    [Fact]
    public void Should_be_able_to_create()
    {
        // Arrange
        var id = Guid.NewGuid();
        // Act
        var mockIdentifier = new Mock<Identifier>(id);
        var identifier = mockIdentifier.Object;
        // Assert
        Assert.Equal(id, identifier.Value);
    }

    [Fact]
    public void Should_be_able_to_check_equality()
    {
        // Arrange
        var id = Guid.NewGuid();
        var firstMockIdentifier = new Mock<Identifier>(id);
        var firstIdentifier = firstMockIdentifier.Object;
        var secondMockIdentifier = new Mock<Identifier>(id);
        var secondIdentifier = secondMockIdentifier.Object;
        // Act
        var areEqualsUsingMethod = firstIdentifier.Equals(secondIdentifier);
        var areEqualsUsingOperator = firstIdentifier == secondIdentifier;
        // Assert
        Assert.True(areEqualsUsingMethod);
        Assert.True(areEqualsUsingOperator);
    }

    [Fact]
    public void Should_be_able_to_check_inequality()
    {
        // Arrange
        var firstId = Guid.NewGuid();
        var secondId = Guid.NewGuid();
        var firstMockIdentifier = new Mock<Identifier>(firstId);
        var firstIdentifier = firstMockIdentifier.Object;
        var secondMockIdentifier = new Mock<Identifier>(secondId);
        var secondIdentifier = secondMockIdentifier.Object;
        // Act
        var areEqualsUsingMethod = firstIdentifier.Equals(secondIdentifier);
        var areEqualsUsingOperator = firstIdentifier != secondIdentifier;
        // Assert
        Assert.False(areEqualsUsingMethod);
        Assert.True(areEqualsUsingOperator);
    }

    [Fact]
    public void Should_be_able_to_implict_convert_to_Guid()
    {
        // Arrange
        var id = Guid.NewGuid();
        var mockIdentifier = new Mock<Identifier>(id);
        var identifier = mockIdentifier.Object;
        // Act
        Guid convertedId = identifier;
        // Assert
        Assert.Equal(id, convertedId);
    }
}